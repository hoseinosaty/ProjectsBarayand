using Barayand.DAL.Interfaces;
using Barayand.Models.Entity;
using Barayand.Models.RuntimeModels;
using Barayand.OutModels.Miscellaneous;
using Barayand.OutModels.Response;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Barayand.DAL.Repositories
{
    public class PCalcRepository : IPCalcRepository
    {
        private readonly IPublicMethodRepsoitory<ProductCombineModel> _combinerepo;
        private readonly IPromotionBoxProdRepository _boxProdRepository;
        private readonly IPublicMethodRepsoitory<FormulaModel> _formularepo;
        private readonly IPublicMethodRepsoitory<CopponModel> _couponrepo;
        private readonly IFestivalRepository _festrepo;
        private readonly ILogger<PCalcRepository> _logger;



        public PCalcRepository(IPublicMethodRepsoitory<FormulaModel> formularepo, IPublicMethodRepsoitory<CopponModel> couponrepo, ILogger<PCalcRepository> logger, IPromotionBoxProdRepository boxProdRepository, IPublicMethodRepsoitory<ProductCombineModel> combinemodel)
        {
            this._formularepo = formularepo;
            this._couponrepo = couponrepo;
            this._logger = logger;
            this._boxProdRepository = boxProdRepository;
            this._combinerepo = combinemodel;
        }

        public async Task<ProductCombineModel> CalculateProductPrice(int pid, int EndLevelCatId = 0)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");

            ProductCombineModel ProductCombine = new ProductCombineModel();
            try
            {
                ProductCombinePriceModel PriceModel = new ProductCombinePriceModel();
                List<FestivalOfferModel> AllFestivalRepo = ((List<FestivalOfferModel>)(await _festrepo.GetAll()).Data);
                var existsInBox = await _boxProdRepository.CheckProductEixstsInBoxs(pid);

                //product exists in boxs
                if (existsInBox != null)
                {
                    var defaultCombine = ((List<ProductCombineModel>)(await _combinerepo.GetAll()).Data).FirstOrDefault(x => x.X_ColorId == existsInBox.X_ColorId && x.X_WarrantyId == existsInBox.X_WarrantyId);
                    if (defaultCombine == null)
                    {
                        return await CalculateDefaultCombine(pid);
                    }

                    ProductCombine = defaultCombine;
                    PriceModel.Price = defaultCombine.X_Price;
                    if (existsInBox.X_SectionId == 34 && (DateTime.Now >= existsInBox.X_StartDate && DateTime.Now <= existsInBox.X_EndDate))//is special sale and timer started
                    {
                        if (existsInBox.X_DiscountedPrice > 0)//has discount
                        {
                            PriceModel.HasDiscount = true;
                            if (!existsInBox.X_DiscountType) // please calculate price by percentage
                            {
                                PriceModel.Discount = existsInBox.X_DiscountedPrice;
                                PriceModel.DiscountedPrice = (defaultCombine.X_Price - ((defaultCombine.X_Price * existsInBox.X_DiscountedPrice) / 100));
                            }
                            else//calculate percentage by price
                            {
                                PriceModel.Discount = ((existsInBox.X_DiscountedPrice * 100) / defaultCombine.X_Price);
                                PriceModel.DiscountedPrice = existsInBox.X_DiscountedPrice;
                            }
                        }
                        PriceModel.Timer = existsInBox.X_EndDate.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        return await CalculateDefaultCombine(pid);
                    }
                    if (existsInBox.X_SectionId != 34)
                    {
                        if (existsInBox.X_DiscountedPrice > 0)//has discount
                        {
                            PriceModel.HasDiscount = true;
                            if (!existsInBox.X_DiscountType) // please calculate price by percentage
                            {
                                PriceModel.Discount = existsInBox.X_DiscountedPrice;
                                PriceModel.DiscountedPrice = (defaultCombine.X_Price - ((defaultCombine.X_Price * existsInBox.X_DiscountedPrice) / 100));
                            }
                            else//calculate percentage by price
                            {
                                PriceModel.Discount = ((existsInBox.X_DiscountedPrice * 100) / defaultCombine.X_Price);
                                PriceModel.DiscountedPrice = existsInBox.X_DiscountedPrice;
                            }
                        }
                    }
                }
                else if (AllFestivalRepo.Count(x => x.F_Type == 1 && x.F_Status) > 0)
                {
                    var fest = AllFestivalRepo.FirstOrDefault(x => x.F_Type == 1);
                    var defaultCombine = await CalculateDefaultCombine(pid);
                    return await CalculateDefaultCombine(pid,fest.F_Discount);
                }
                else if(EndLevelCatId != 0 && AllFestivalRepo.Count(x=>x.F_Type == 2 && x.F_Status && x.F_EndLevelCategoryId == EndLevelCatId) > 0)
                {
                    var fest = AllFestivalRepo.FirstOrDefault(x => x.F_Type == 2 && x.F_Status && x.F_EndLevelCategoryId == EndLevelCatId);
                    var defaultCombine = await CalculateDefaultCombine(pid);
                    return await CalculateDefaultCombine(pid, fest.F_Discount);
                }
                else
                {
                    return await CalculateDefaultCombine(pid);
                }
                ProductCombine.PriceModel = PriceModel;
                return ProductCombine;
            }
            catch (Exception ex)
            {
                return ProductCombine;
            }
        }
        private async Task<ProductCombineModel> CalculateDefaultCombine(int pid,decimal discount = 0)
        {
            ProductCombineModel ProductCombine = new ProductCombineModel();
            try
            {
                ProductCombinePriceModel PriceModel = new ProductCombinePriceModel();
                //product not exists in boxs
                var getAllCombines = ((List<ProductCombineModel>)(await _combinerepo.GetAll()).Data).Where(x => x.X_ProductId == pid && x.X_Status && !x.X_IsDeleted);
                if (getAllCombines.Count() > 0)//combines set for current product
                {
                    var defaultCombine = getAllCombines.FirstOrDefault(x => x.X_Default);
                    if (defaultCombine != null)//has default combine
                    {
                        ProductCombine = defaultCombine;
                        PriceModel.Price = defaultCombine.X_Price;
                        if(discount != 0)
                        {
                            defaultCombine.X_Discount = discount;
                            defaultCombine.X_DiscountType = 1;
                        }
                        if (defaultCombine.X_Discount > 0)//has discount
                        {
                            PriceModel.HasDiscount = true;
                            if (defaultCombine.X_DiscountType == 1) // please calculate price by percentage
                            {
                                PriceModel.Discount = defaultCombine.X_Discount;
                                PriceModel.DiscountedPrice = (defaultCombine.X_Price - ((defaultCombine.X_Price * defaultCombine.X_Discount) / 100));
                            }
                            else//calculate percentage by price
                            {
                                PriceModel.Discount = ((defaultCombine.X_Discount * 100) / defaultCombine.X_Price);
                                PriceModel.DiscountedPrice = defaultCombine.X_Discount;
                            }
                        }
                    }
                }
                ProductCombine.PriceModel = PriceModel;
                return ProductCombine;
            }
            catch (Exception ex)
            {
                return ProductCombine;
            }
        }
    }
}
