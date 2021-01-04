﻿using Barayand.DAL.Context;
using Barayand.DAL.Interfaces;
using Barayand.Models.Entity;
using Barayand.OutModels.Miscellaneous;
using Barayand.OutModels.Models;
using Barayand.OutModels.Response;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Barayand.DAL.Repositories
{
    public class ProductRepository : GenericRepository<ProductModel>, IPublicMethodRepsoitory<ProductModel>
    {
        private readonly BarayandContext _context;
        private readonly IPCRepository _pCRepository;
        private readonly IPCalcRepository _priceCalculator;
      
        public ProductRepository(BarayandContext context,IPCRepository pCRepository, IPCalcRepository priceCalculator) : base(context)
        {
            this._context = context;
            this._pCRepository = pCRepository;
            _priceCalculator = priceCalculator;
        }
        public async Task<ResponseStructure> LogicalAvailable(object id, bool newState)
        {
            try
            {
                var item = await this.GetById(id);
                item.P_Status = newState;
                return await this.Update(item);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<ResponseStructure> LogicalDelete(object id)
        {
            try
            {
                var item = await this.GetById(id);
                item.P_IsDeleted = true;
                return await this.Update(item);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<ResponseStructure> Insert(ProductModel entity)
        {
            try
            {
                var getProdsByCats = this._context.Product.Where(x=>x.P_MainCatId == entity.P_MainCatId && x.P_EndLevelCatId == entity.P_EndLevelCatId).ToList();
                int Seed = 1;
                if(getProdsByCats.Count() > 0)
                {
                    Seed = getProdsByCats.Max(x => x.P_Id) + 1;
                }
                    entity.P_Code ="HKO"+ entity.P_MainCatId +""+ entity.P_EndLevelCatId + ""+entity.P_BrandId+"0" +Seed;
                    this._context.Product.Add(entity);
                    await this.CommitAllChanges();
                    //Product Atrribute And Answer Registration

                    int pid = entity.P_Id;//product id
                    if (!string.IsNullOrEmpty(entity.P_DedicatedField))
                    {
                        List<IncomeProdFieldSetModel> DedicatedFields = JsonConvert.DeserializeObject<List<IncomeProdFieldSetModel>>(entity.P_DedicatedField);
                        if (DedicatedFields != null)
                        {
                            List<ProductAttributeModel> Attributes = new List<ProductAttributeModel>();
                            foreach (var item in DedicatedFields)
                            {
                                int AnswerId = 0;
                                bool isInteger = int.TryParse(item.value + "", out AnswerId);
                                Attributes.Add(new ProductAttributeModel()
                                {
                                    X_AId = item.id,
                                    X_AnswerId = (isInteger) ? AnswerId : 0,
                                    X_AnswerTitle = (!isInteger) ? item.value : null,
                                    X_PId = pid
                                });
                            }
                            this._context.ProductAttributeAnswer.AddRange(Attributes);
                            await this.CommitAllChanges();
                        }
                    }
                    if (entity.P_LabelIds.Length > 0)
                    {
                        List<ProductLabelRelationModel> Relations = new List<ProductLabelRelationModel>();
                        foreach (var item in entity.P_LabelIds)
                        {
                            Relations.Add(new ProductLabelRelationModel()
                            {
                                X_LabelId = item,
                                X_Pid = pid
                            });
                        }
                        this._context.ProductLabelRelation.AddRange(Relations);
                        await this.CommitAllChanges();
                    }

                return ResponseModel.Success("operation successfully completed");
            }
            catch (Exception ex)
            {
                return ResponseModel.ServerInternalError(data: ex);
            }
        }
        public async Task<ResponseStructure> Update(ProductModel entity)
        {
            try
            {
                var item = await this.GetById(entity.P_Id);
                entity.Created_At = item.Created_At;
                entity.Updated_At = DateTime.Now;
                this._context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                this._context.Product.Update(entity);
                await this.CommitAllChanges();
                //Product Atrribute And Answer Registration
                if (this._context.ProductAttributeAnswer.Count(x => x.X_PId == entity.P_Id) > 0)
                {
                    this._context.ProductAttributeAnswer.RemoveRange(this._context.ProductAttributeAnswer.Where(x => x.X_PId == entity.P_Id).ToList());
                    await this.CommitAllChanges();
                }
                if (this._context.ProductLabelRelation.Count(x => x.X_Pid == entity.P_Id) > 0)
                {
                    this._context.ProductLabelRelation.RemoveRange(this._context.ProductLabelRelation.Where(x => x.X_Pid == entity.P_Id).ToList());
                    await this.CommitAllChanges();
                }
                int pid = entity.P_Id;//product id
                if (!string.IsNullOrEmpty(entity.P_DedicatedField))
                {
                    List<IncomeProdFieldSetModel> DedicatedFields = JsonConvert.DeserializeObject<List<IncomeProdFieldSetModel>>(entity.P_DedicatedField);
                    if (DedicatedFields != null)
                    {
                        List<ProductAttributeModel> Attributes = new List<ProductAttributeModel>();
                        foreach (var ditem in DedicatedFields)
                        {
                            int AnswerId = 0;
                            bool isInteger = int.TryParse(ditem.value + "", out AnswerId);
                            Attributes.Add(new ProductAttributeModel()
                            {
                                X_AId = ditem.id,
                                X_AnswerId = (isInteger) ? AnswerId : 0,
                                X_AnswerTitle = (!isInteger) ? ditem.value : null,
                                X_PId = pid
                            });
                        }
                        await this._context.ProductAttributeAnswer.AddRangeAsync(Attributes);
                        await this.CommitAllChanges();
                    }
                }
                if (entity.P_LabelIds.Length > 0)
                {
                    List<ProductLabelRelationModel> Relations = new List<ProductLabelRelationModel>();
                    foreach (var litem in entity.P_LabelIds)
                    {
                        Relations.Add(new ProductLabelRelationModel()
                        {
                            X_LabelId = litem,
                            X_Pid = pid
                        });
                    }
                    await this._context.ProductLabelRelation.AddRangeAsync(Relations);
                    await this.CommitAllChanges();
                }

                return ResponseModel.Success("رکورد مورد نظر با موفقیت بروزرسانی گردید");
            }
            catch (Exception ex)
            {
                return ResponseModel.ServerInternalError(data: ex);
            }
        }
        public async Task<ProductModel> GetById(object id)
        {
            try
            {
                ProductModel AllProducts = this._context.Product.FirstOrDefault(x => x.P_IsDeleted == false && x.P_Id == int.Parse(id.ToString()));
                if (AllProducts == null)
                {
                    return null;
                }
                List<ProductCategoryModel> AllCategories = this._context.ProductCategory.ToList();
                List<BrandModel> AllBrands = this._context.Brands.ToList();
                List<ProductLabelRelationModel> AllLabels = this._context.ProductLabelRelation.ToList();
                List<ProductLabelModel> AllLabelTable = this._context.ProductLabel.ToList();
                List<ProductCombineModel> AllCombines = this._context.ProductCombine.Where(x => !x.X_IsDeleted).ToList();
                List<ColorModel> AllColors = this._context.Color.Where(x => !x.C_IsDeleted).ToList();
                List<WarrantyModel> AllWarranties = this._context.Warranty.Where(x => !x.W_IsDeleted).ToList();

                string cattitle = "";
                string brandtitle = "";
                var cat = AllCategories.FirstOrDefault(x => x.PC_Id == AllProducts.P_EndLevelCatId);
                var brand = AllBrands.FirstOrDefault(x => x.B_Id == AllProducts.P_BrandId);
                if (cat != null)
                {
                    cattitle = cat.PC_Title;
                }
                if (brand != null)
                {
                    brandtitle = brand.B_Title;
                }
                AllProducts.P_CatTitle = cattitle;
                AllProducts.P_BrandTitle = brandtitle;
                var prdslabel = AllLabels.Where(x => x.X_Pid == AllProducts.P_Id).ToList();
                if (prdslabel != null)
                {
                    AllProducts.P_LabelIds = prdslabel.Select(x => x.X_LabelId).ToArray();
                    List<ProductLabelModel> Labels = new List<ProductLabelModel>();
                    foreach (var lid in prdslabel)
                    {
                        Labels.Add(AllLabelTable.FirstOrDefault(x => x.L_Id == lid.X_LabelId));
                    }
                    AllProducts.P_Labels = Labels;
                }
                var prdDedicatedFields = _context.ProductAttributeAnswer.Where(x => x.X_PId == AllProducts.P_Id).ToList();
                List<IncomeProdFieldSetModel> dedicated = new List<IncomeProdFieldSetModel>();
                foreach (var d in prdDedicatedFields)
                {
                    IncomeProdFieldSetModel ipfs = new IncomeProdFieldSetModel();
                    ipfs.id = d.X_AId;
                    if (d.X_AnswerId == 0)
                    {
                        ipfs.value = d.X_AnswerTitle;
                    }
                    else
                    {
                        ipfs.value = d.X_AnswerId;
                    }
                    dedicated.Add(ipfs);
                }
                AllProducts.P_DedicatedField = JsonConvert.SerializeObject(dedicated);
                AllProducts.P_ParentCategories = await this._pCRepository.GetCategoryParents(AllProducts.P_EndLevelCatId);

                var ProductCombines = AllCombines.Where(x => x.X_ProductId == AllProducts.P_Id).ToList();
                if (ProductCombines != null && ProductCombines.Count > 0)
                {
                    List<Models.KeyValueModel.Warranty> warranties = new List<Models.KeyValueModel.Warranty>();
                    List<Models.KeyValueModel.Color> colors = new List<Models.KeyValueModel.Color>();
                    int AvlCount = 0;
                    foreach (var combine in ProductCombines)
                    {
                        if (combine.X_AvailableCount > 1)
                        {
                            var w = AllWarranties.FirstOrDefault(x => x.W_Id == combine.X_WarrantyId);
                            if (w != null && warranties.Count(x => x.Id == w.W_Id) < 1)
                            {
                                warranties.Add(new Models.KeyValueModel.Warranty() { Id = w.W_Id, Title = w.W_Title });
                            }
                            var c = AllColors.FirstOrDefault(x => x.C_Id == combine.X_ColorId);
                            if (c != null && colors.Count(x => x.Id == c.C_Id) < 1)
                            {
                                colors.Add(new Models.KeyValueModel.Color() { Id = c.C_Id, ColorCode = c.C_HexColor,Title = c.C_Title });
                            }
                        }
                        AvlCount += combine.X_AvailableCount;
                            
                    }
                    AllProducts.DefaultProductCombine = await _priceCalculator.CalculateProductPrice(int.Parse(id.ToString()),AllProducts.P_EndLevelCatId) ;
                    if (AvlCount > 0)
                    {
                        AllProducts.Warranties = warranties;
                        AllProducts.Colors = colors;
                        AllProducts.IsAvailable = true;
                    }
                    AllProducts.Cuntry = _context.ManufacturingCuntry.FirstOrDefault(x => x.M_Id == AllProducts.P_MCuntryId);
                }

                var getRelatedProducts = _context.RelatedProduct.Where(x=>x.X_MainProdId == AllProducts.P_Id).ToList();
                var getCompletelyProducts = _context.PerfectProduct.Where(x=>x.X_MainProdId == AllProducts.P_Id).ToList();
                var getSetProducts = _context.SetProduct.Where(x=>x.X_MainProdId == AllProducts.P_Id).ToList();

                foreach(var rp in getRelatedProducts)
                {
                    if(AllProducts.RelatedProducts.Count(x=>x.P_Id != rp.X_ProdId) < 1)
                    {
                        var prod = await GetById(rp.X_ProdId);
                        AllProducts.RelatedProducts.Add(prod);
                    }
                }
                foreach (var rp in getCompletelyProducts)
                {
                    if (AllProducts.CompletelyProducts.Count(x => x.P_Id != rp.X_ProdId) < 1)
                    {
                        var prod = await GetById(rp.X_ProdId);
                        AllProducts.CompletelyProducts.Add(prod);
                    }
                }
                foreach (var rp in getSetProducts)
                {
                    if (AllProducts.SetProducts.Count(x => x.P_Id != rp.X_ProdId) < 1)
                    {
                        var prod = await GetById(rp.X_ProdId);
                        AllProducts.SetProducts.Add(prod);
                    }
                }
                var attrs = _context.ProductAttributeAnswer.Where(x => x.X_PId == AllProducts.P_Id).ToList();
                List<AttributeStructure> attributeStructures = new List<AttributeStructure>();
                foreach (var attr in attrs)
                {
                    var attribute = _context.Attribute.FirstOrDefault(x => x.A_Id == attr.X_AId);
                    var answer = "";
                    if (attr.X_AnswerId == 0)
                    {
                        answer = attr.X_AnswerTitle;
                    }
                    else
                    {
                        var Ans = _context.AttributeAnswer.FirstOrDefault(x => x.X_Id == attr.X_AnswerId);
                        if (Ans != null)
                        {
                            answer = Ans.X_Answer;
                        }
                    }
                    if (attribute != null)
                    {
                        attributeStructures.Add(new AttributeStructure()
                        {
                            AnswerTitle = answer,
                            AttributeTitle = attribute.A_Title,
                            AttributeId = attribute.A_Id
                        });
                    }
                    
                }
                AllProducts.P_AttributeStructures = attributeStructures;
                AllProducts.Comments  = _context.Comment.Where(x => x.C_EntityId == AllProducts.P_Id && x.C_Type == 1 && x.C_Status == 2).ToList();
                return AllProducts;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<ResponseStructure> GetAll()
        {
            try
            {
                List<ProductModel> AllProducts = this._context.Product.Where(x => x.P_IsDeleted == false).ToList();
                List<ProductCategoryModel> AllCategories = this._context.ProductCategory.ToList();
                List<BrandModel> AllBrands = this._context.Brands.ToList();
                List<ProductLabelRelationModel> AllLabels = this._context.ProductLabelRelation.ToList();
                List<ProductLabelModel> AllLabelTable = this._context.ProductLabel.ToList();
                List<ProductCombineModel> AllCombines = this._context.ProductCombine.Where(x => !x.X_IsDeleted).ToList();
                List<ColorModel> AllColors = this._context.Color.Where(x => !x.C_IsDeleted).ToList();
                List<WarrantyModel> AllWarranties = this._context.Warranty.Where(x => !x.W_IsDeleted).ToList();

                foreach (var item in AllProducts)
                {
                    string cattitle = "";
                    string brandtitle = "";
                    var cat = AllCategories.FirstOrDefault(x => x.PC_Id == item.P_EndLevelCatId);
                    var brand = AllBrands.FirstOrDefault(x => x.B_Id == item.P_BrandId);
                    if (cat != null)
                    {
                        cattitle = cat.PC_Title;
                    }
                    if (brand != null)
                    {
                        brandtitle = brand.B_Title;
                    }
                    AllProducts.FirstOrDefault(x => x.P_Id == item.P_Id).P_CatTitle = cattitle;
                    AllProducts.FirstOrDefault(x => x.P_Id == item.P_Id).P_BrandTitle = brandtitle;
                    var prdslabel = AllLabels.Where(x => x.X_Pid == item.P_Id).ToList();
                    if (prdslabel != null)
                    {
                        AllProducts.FirstOrDefault(x => x.P_Id == item.P_Id).P_LabelIds = prdslabel.Select(x => x.X_LabelId).ToArray();
                        List<ProductLabelModel> Labels = new List<ProductLabelModel>();
                        foreach (var lid in prdslabel)
                        {
                            Labels.Add(AllLabelTable.FirstOrDefault(x => x.L_Id == lid.X_LabelId));
                        }
                        AllProducts.FirstOrDefault(x => x.P_Id == item.P_Id).P_Labels = Labels;
                    }
                    var prdDedicatedFields = _context.ProductAttributeAnswer.Where(x => x.X_PId == item.P_Id).ToList();
                    List<IncomeProdFieldSetModel> dedicated = new List<IncomeProdFieldSetModel>();
                    foreach (var d in prdDedicatedFields)
                    {
                        IncomeProdFieldSetModel ipfs = new IncomeProdFieldSetModel();
                        ipfs.id = d.X_AId;
                        if (d.X_AnswerId == 0)
                        {
                            ipfs.value = d.X_AnswerTitle;
                        }
                        else
                        {
                            ipfs.value = d.X_AnswerId;
                        }
                        dedicated.Add(ipfs);
                    }
                    item.P_DedicatedField = JsonConvert.SerializeObject(dedicated);
                    AllProducts.FirstOrDefault(x => x.P_Id == item.P_Id).P_ParentCategories = await this._pCRepository.GetCategoryParents(item.P_EndLevelCatId);

                    var ProductCombines = AllCombines.Where(x => x.X_ProductId == item.P_Id).ToList();
                    if (ProductCombines != null && ProductCombines.Count > 0)
                    {
                        List<Models.KeyValueModel.Warranty> warranties = new List<Models.KeyValueModel.Warranty>();
                        List<Models.KeyValueModel.Color> colors = new List<Models.KeyValueModel.Color>();
                        int AvlCount = 0;
                        foreach (var combine in ProductCombines)
                        {
                            if (combine.X_AvailableCount > 1)
                            {
                                var w = AllWarranties.FirstOrDefault(x => x.W_Id == combine.X_WarrantyId);
                                if (w != null && warranties.Count(x => x.Id == w.W_Id) < 1)
                                {
                                    warranties.Add(new Models.KeyValueModel.Warranty() { Id = w.W_Id, Title = w.W_Title });
                                }
                                var c = AllColors.FirstOrDefault(x => x.C_Id == combine.X_ColorId);
                                if (c != null && colors.Count(x => x.Id == c.C_Id) < 1)
                                {
                                    colors.Add(new Models.KeyValueModel.Color() { Id = c.C_Id, ColorCode = c.C_HexColor, Title = c.C_Title });
                                }
                            }
                            AvlCount += combine.X_AvailableCount;
                        }
                        item.DefaultProductCombine = await _priceCalculator.CalculateProductPrice(item.P_Id, item.P_EndLevelCatId);
                        if (AvlCount > 0)
                        {
                            item.Warranties = warranties;
                            item.Colors = colors;
                            item.IsAvailable = true;
                        }
                    }

                }
                return ResponseModel.Success(data: AllProducts);
            }
            catch (Exception ex)
            {
                return ResponseModel.Error(msg: ex.Message, data: ex);
            }
        }
    }
}
