﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Barayand.DAL.Interfaces;
using Barayand.Models.Entity;
using Barayand.OutModels.Miscellaneous;
using Barayand.OutModels.Models;
using Barayand.OutModels.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Barayand.Controllers.Cpanel.Requests
{
    [Route("api/cpanel/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IPublicMethodRepsoitory<InvoiceModel> _invoicerepo;
        private readonly IPublicMethodRepsoitory<OrderModel> _orderrepo;
        private readonly IUserRepository _userrepo;
        private readonly ILogger<RequestController> _logger;
        private readonly IPublicMethodRepsoitory<ProductModel> _productrepo;
        private readonly IPublicMethodRepsoitory<OfflinRequestModel> _offreqrepo;
        private readonly IPublicMethodRepsoitory<CopponModel> _copponrepo;
        public RequestController(IPublicMethodRepsoitory<InvoiceModel> invoicerepo, IPublicMethodRepsoitory<OrderModel> orderrepo, IUserRepository userrepo, ILogger<RequestController> logger, IPublicMethodRepsoitory<ProductModel> productrepo, IPublicMethodRepsoitory<CopponModel> copponrepo, IPublicMethodRepsoitory<OfflinRequestModel> offreqrepo)
        {
            _invoicerepo = invoicerepo;
            _orderrepo = orderrepo;
            _userrepo = userrepo;
            _logger = logger;
            _productrepo = productrepo;
            _copponrepo = copponrepo;
            _offreqrepo = offreqrepo;
        }
        [Route("LoadInvoices")]
        [HttpPost]
        public async Task<ActionResult> LoadInvoices()
        {
            try
            {
                var invoices = ((List<InvoiceModel>)(await _invoicerepo.GetAll()).Data);
                List<object> result = new List<object>();
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa");
                int i = 1;
                foreach(var item in invoices.OrderByDescending(x=>x.Created_At))
                {
                    var orders = ((List<OrderModel>)(await _orderrepo.GetAll()).Data).Where(x=>x.O_ReciptId == item.I_Id).ToList();
                    List<object> InvoiceOrders = new List<object>();
                    int j = 1;
                    foreach(var o in orders)
                    {
                        var product = await _productrepo.GetById(o.O_ProductId);
                        if(product != null)
                        {
                            InvoiceOrders.Add(new {
                                Counter = j,
                                Name = product.P_Title,
                                Image = product.P_Image,
                                Price = o.O_Price,
                                PriceWODiscount = o.O_Discount,
                                Quantity = o.O_Quantity,
                                Version = o.O_Version,
                                Lang = o.Lang
                            });
                            j++;
                        }
                    }
                    var user = await _userrepo.GetById(item.I_UserId);
                    var coupon = await _copponrepo.GetById(item.I_CopponId);
                    result.Add(new {
                        Counter = i,
                        Id = item.ID,
                        Code = item.I_Id,
                        User = (user != null) ? user.U_Name+" "+ user.U_Family : "",
                        Sum = item.I_TotalAmount,
                        SumProducts = item.I_TotalProductAmount,
                        CouponCode = (coupon != null) ? coupon.CP_Code : "",
                        CouponPerc = item.I_CopponDiscount,
                        PaymentType = item.I_PaymentType,
                        BankName = "Test Payment",
                        CardNumber = "Test Payment",
                        PaymentDate = ((DateTime)item.Created_At).ToString("yyyy/MM/dd HH:mm:ss"),
                        Status = item.I_Status,
                        Reciption = (item.I_RecipientInfo != null) ? JsonConvert.DeserializeObject<ReciptientInfoModel>(item.I_RecipientInfo) : null,
                        Products = InvoiceOrders
                    });
                    i++;
                }
                return new JsonResult(ResponseModel.Success(data:result));
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in loading invoices",ex);
                return new JsonResult(ResponseModel.ServerInternalError(data:ex));
            }
        }
        [Route("LoadOffReqs")]
        [HttpPost]
        public async Task<ActionResult> LoadOffRequests()
        {
            try
            {
                var AllReqs = (List<OfflinRequestModel>)(await _offreqrepo.GetAll()).Data;
                List<object> result = new List<object>();
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa");
                int i = 1;
                foreach(var item in AllReqs.OrderByDescending(x=>(DateTime)x.Created_At))
                {
                    var user = await _userrepo.GetById(item.O_User);
                    result.Add(new {
                        id = item.O_Id,
                        counter = i,
                        user = (user != null) ? user.U_Name+" "+user.U_Family : "",
                        url = item.O_Url,
                        detail = item.O_Details,
                        price = item.O_Price,
                        deliver = item.O_DeliverDate,
                        reqdate = ((DateTime)item.Created_At).ToString("yyyy/MM/dd HH:mm:ss"),
                        reason = item.O_Reason,
                        status = item.O_Status
                    });
                    i++;
                }
                return new JsonResult(ResponseModel.Success(data:result)); 
            }
            catch(Exception ex)
            {
                _logger.LogError("Error",ex);
                return new JsonResult(ResponseModel.ServerInternalError(data:ex));
            }
        }
        [Route("offReqChangeState")]
        [HttpPost]
        public async Task<ActionResult> ChangeStateOfOfflineRequest(OfflineRequestChangeState orcs)
        {
            try
            {
                var AllReqs = (List<OfflinRequestModel>)(await _offreqrepo.GetAll()).Data;
                var req = AllReqs.FirstOrDefault(x=>x.O_Id == orcs.id);
                if(req == null)
                {
                    return new JsonResult(ResponseModel.Error("درخواست مورد نظر یافت نشد"));
                }
                req.O_Status = orcs.state;
                req.O_Reason = orcs.reason;
                req.O_Price = orcs.price;
                req.O_DeliverDate = orcs.deliver;
                return new JsonResult(await _offreqrepo.Update(req));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                return new JsonResult(ResponseModel.ServerInternalError(data: ex));
            }
        }
    }
}
