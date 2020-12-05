using Barayand.DAL.Context;
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
        public ProductRepository(BarayandContext context,IPCRepository pCRepository) : base(context)
        {
            this._context = context;
            this._pCRepository = pCRepository;
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
                entity.P_Code = entity.P_Code + DateTime.Now.ToString("yyyyMMddHHmmss");
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
        public async Task<ResponseStructure> GetAll()
        {
            try
            {
                List<ProductModel> AllProducts = this._context.Product.Where(x=>x.P_IsDeleted == false).ToList();
                List<ProductCategoryModel> AllCategories = this._context.ProductCategory.ToList();
                List<BrandModel> AllBrands = this._context.Brands.ToList();
                List<ProductLabelRelationModel> AllLabels = this._context.ProductLabelRelation.ToList();
                List<ProductLabelModel> AllLabelTable = this._context.ProductLabel.ToList();
                foreach(var item in AllProducts)
                {
                    string cattitle = "";
                    string brandtitle = "";
                    var cat = AllCategories.FirstOrDefault(x=>x.PC_Id == item.P_EndLevelCatId);
                    var brand = AllBrands.FirstOrDefault(x=>x.B_Id == item.P_BrandId);
                    if(cat != null)
                    {
                        cattitle = cat.PC_Title;
                    }
                    if(brand != null)
                    {
                        brandtitle = brand.B_Title;
                    }
                    AllProducts.FirstOrDefault(x => x.P_Id == item.P_Id).P_CatTitle = cattitle;
                    AllProducts.FirstOrDefault(x => x.P_Id == item.P_Id).P_BrandTitle = brandtitle;
                    var prdslabel = AllLabels.Where(x=>x.X_Pid == item.P_Id).ToList();
                    if(prdslabel != null)
                    {
                        AllProducts.FirstOrDefault(x => x.P_Id == item.P_Id).P_LabelIds = prdslabel.Select(x=>x.X_LabelId).ToArray();
                        List<ProductLabelModel> Labels = new List<ProductLabelModel>();
                        foreach(var lid in prdslabel)
                        {
                            Labels.Add(AllLabelTable.FirstOrDefault(x=>x.L_Id == lid.X_LabelId));
                        }
                        AllProducts.FirstOrDefault(x => x.P_Id == item.P_Id).P_Labels = Labels;
                    }
                    var prdDedicatedFields = _context.ProductAttributeAnswer.Where(x=>x.X_PId == item.P_Id).ToList();
                    List<IncomeProdFieldSetModel> dedicated = new List<IncomeProdFieldSetModel>();
                    foreach (var d in prdDedicatedFields)
                    {
                        IncomeProdFieldSetModel ipfs  = new IncomeProdFieldSetModel();
                        ipfs.id = d.X_AId;
                        if(d.X_AnswerId == 0)
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
                }
                return ResponseModel.Success(data:AllProducts);
            }
            catch (Exception ex)
            {
                return ResponseModel.Error(msg: ex.Message, data: ex);
            }
        }

    }
}
