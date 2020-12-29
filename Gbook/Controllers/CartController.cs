using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Barayand.Common.Services;
using Barayand.DAL.Interfaces;
using Barayand.Models.Entity;
using Barayand.OutModels.Miscellaneous;
using Barayand.OutModels.Response;
using Barayand.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Gbook.Controllers
{
    public class CartController : Controller
    {
        public readonly IPublicMethodRepsoitory<ProductModel> _repository;
        public readonly IPublicMethodRepsoitory<UserModel> _userrepository;
        public readonly IPublicMethodRepsoitory<CopponModel> _copponrepository;
        public readonly IPublicMethodRepsoitory<InvoiceModel> _invoicerepository;
        public readonly IPublicMethodRepsoitory<OrderModel> _orderrepository;
        public readonly IPublicMethodRepsoitory<OptionsModel> _optionrepository;
        private readonly IPublicMethodRepsoitory<DynamicPagesContent> _DynamicPageRepository;
        private readonly IPaymentService _paymentService;
        private readonly IWalletHistoryRepository _walletrepository;
        private readonly IViewRenderer renderer;
        private readonly IBasketService _basketservice;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _lang;
        private readonly IPriceCalculatorService _priceCalculator;
        public CartController(IPublicMethodRepsoitory<ProductModel> repository, IPublicMethodRepsoitory<UserModel> userrepository, IPublicMethodRepsoitory<CopponModel> copponrepository, IPaymentService paymentService, IPublicMethodRepsoitory<InvoiceModel> invoicerepository, IPublicMethodRepsoitory<OrderModel> orderrepository, IPublicMethodRepsoitory<DynamicPagesContent> DynamicPageRepository, IWalletHistoryRepository walletHistoryRepository, IViewRenderer viewRenderer, IBasketService basketService, IMapper mapper, IPriceCalculatorService priceCalculator, ILocalizationService lang, IPublicMethodRepsoitory<OptionsModel> optionrepository)
        {
            _repository = repository;
            _userrepository = userrepository;
            _copponrepository = copponrepository;
            _paymentService = paymentService;
            _invoicerepository = invoicerepository;
            _orderrepository = orderrepository;
            _DynamicPageRepository = DynamicPageRepository;
            _walletrepository = walletHistoryRepository;
            renderer = viewRenderer;
            _basketservice = basketService;
            _mapper = mapper;
            _optionrepository = optionrepository;
            _priceCalculator = priceCalculator;
            _lang = lang;
        }
        public async Task<IActionResult> Index()
        {
            var basket = await _basketservice.GetBasketItems(Request);
            foreach (var item in basket.CartItems)
            {
                item.Product.PriceModel = await _priceCalculator.CalculateBookPrice(item.Product.P_Id,_lang.GetLang());
            }
            ViewBag.CVRT = 1000;
            ViewBag.BINPERC = 1;
            var cvrtbase = ((List<OptionsModel>)(await _optionrepository.GetAll()).Data).FirstOrDefault(x => x.O_Key == "CVRTTOMANTOPOINT");
            var bin = ((List<OptionsModel>)(await _optionrepository.GetAll()).Data).FirstOrDefault(x => x.O_Key == "GIFTBINPERCENTAGE");
            if (bin != null)
            {
                ViewBag.BINPERC = int.Parse(bin.O_Value);
            }
            if (cvrtbase != null)
            {
                ViewBag.CVRT = int.Parse(cvrtbase.O_Value);
            }
            ViewBag.LoggedIn = TokenService.AuthorizeUser(Request) > 0;
            ViewBag.User = await _userrepository.GetById(TokenService.AuthorizeUser(Request));
            return View(basket);
        }
        [Route("Cart/AddToCart")]
        [HttpPost]
        public async Task<IActionResult> Add()
        {
            try
            {
                return new JsonResult(await _basketservice.AddToCart(Request, Response));
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError());
            }
        }
        [Route("Cart/GetTotalBasketAmount")]
        [HttpPost]
        public async Task<IActionResult> GetTotalBasketAmount()
        {
            try
            {
                var basket = await _basketservice.GetBasketItems(Request);
                if (basket.CartItems.Count < 1)
                {
                    if (_lang.GetLang() == "fa")
                    {
                        return new JsonResult(ResponseModel.Success("Basket is empty.", new { amount = 0 + " تومان" }));
                    }
                    else
                    {
                        return new JsonResult(ResponseModel.Success("Basket is empty.", new { amount = 0 + " Point" }));
                    }
                }
                decimal amount = 0;
                foreach (var item in basket.CartItems)
                {
                    item.Product.PriceModel = await _priceCalculator.CalculateBookPrice(item.Product.P_Id, _lang.GetLang());
                    if (item.PrintAble)
                    {
                        amount = amount + (item.Product.PriceModel.HcopyPrice * item.Quantity);
                    }
                    else
                    {
                        amount = amount + (item.Product.PriceModel.PdfPrice * item.Quantity);
                    }
                }

                if (_lang.GetLang() == "fa")
                {
                    return new JsonResult(ResponseModel.Success("Basket items calculated.", new { amount = ((int)amount).ToString("#,#") + " تومان" }));
                }
                else
                {
                    return new JsonResult(ResponseModel.Success("Basket items calculated.", new { amount = ((int)amount / 1000).ToString("#,#") + " Point" }));
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError());
            }
        }
        [Route("Cart/UseCoppon")]
        [HttpPost]
        public async Task<IActionResult> useCoppon()
        {
            try
            {
                return new JsonResult(await _basketservice.UseCoppon(Request, Response));
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError());
            }
        }
        [Route("Cart/RemoveItem")]
        [HttpPost]
        public async Task<IActionResult> RemoveItem()
        {
            try
            {
                return new JsonResult(await _basketservice.RemoveCartItem(Request, Response));
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError());
            }
        }
        [Route("Cart/SaveReciptientInfo")]
        [HttpPost]
        public async Task<IActionResult> SaveReciptientInfo()
        {
            try
            {
                return new JsonResult(await _basketservice.SaveReciptientInfo(Request, Response));
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError());
            }
        }
        [Route("Cart/TestCheckout/{type?}")]
        [HttpPost]
        public async Task<IActionResult> TestCheckout(int type = 1)
        {
            try
            {
                return new JsonResult(await _basketservice.TestCheckout(Request, Response,type));
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError());
            }
        }
    }
}
