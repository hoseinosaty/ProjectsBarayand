using Barayand.DAL.Context;
using Barayand.DAL.Interfaces;
using Barayand.Models.Entity;
using Barayand.OutModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barayand.DAL.Repositories
{
    public class ProductCombineRepository:GenericRepository<ProductCombineModel>,IPublicMethodRepsoitory<ProductCombineModel>
    {
        private BarayandContext _context;
        public ProductCombineRepository(BarayandContext context):base(context)
        {
            _context = context;
        }

        public async Task<ResponseStructure> LogicalAvailable(object id, bool newState)
        {
            try
            {
                var item = await this.GetById(id);
                item.X_Status = newState;
                return await this.Update(item);
            }
            catch (Exception ex)
            {
                return ResponseModel.ServerInternalError(data:ex);
            }
        }

        public async Task<ResponseStructure> LogicalDelete(object id)
        {
            try
            {
                var item = await this.GetById(id);
                item.X_IsDeleted = true;
                return await this.Update(item);
            }
            catch (Exception ex)
            {
                return ResponseModel.ServerInternalError(data: ex);
            }
        }
        public async Task<ResponseStructure> Update(ProductCombineModel entity)
        {
            try
            {
                var all = ((List<ProductCombineModel>)(await this.GetAll()).Data);
                if(all.Count(x=>x.X_Id != entity.X_Id && x.X_ProductId == entity.X_ProductId && x.X_WarrantyId == entity.X_WarrantyId && x.X_ColorId == entity.X_ColorId && !x.X_IsDeleted) > 0)
                {
                    return ResponseModel.Error("ترکیب آماری مورد نظر برای گارانتی و رنگ انتخابی قبلا تعریف شده است");
                }
                if (entity.X_Default)
                {
                    var allCombines = all.Where(x => x.X_ProductId == entity.X_ProductId).ToList();
                    foreach(var cmb in allCombines)
                    {
                        cmb.X_Default = false;
                    }
                    _context.ProductCombine.UpdateRange(allCombines);
                    await this.CommitAllChanges();
                }
                var item = await this.GetById(entity.X_Id);
                entity.Created_At = item.Created_At;
                entity.Updated_At = DateTime.Now;
                this._context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                this._context.ProductCombine.Update(entity);
                await this._context.SaveChangesAsync();
                return ResponseModel.Success("رکورد مورد نظر با موفقیت بروزرسانی گردید");
            }
            catch (Exception ex)
            {
                return ResponseModel.ServerInternalError(data: ex);
            }
        }
        public async Task<ResponseStructure> Insert(ProductCombineModel entity)
        {
            try
            {
                var all = ((List<ProductCombineModel>)(await this.GetAll()).Data);
                if(all.Count(x=>x.X_ProductId == entity.X_ProductId && x.X_WarrantyId == entity.X_WarrantyId && x.X_ColorId == entity.X_ColorId && !x.X_IsDeleted) > 0)
                {
                    return ResponseModel.Error("ترکیب آماری مورد نظر برای گارانتی و رنگ انتخابی قبلا تعریف شده است");
                }
                if (entity.X_Default)
                {
                    var allCombines = all.Where(x => x.X_ProductId == entity.X_ProductId).ToList();
                    foreach (var cmb in allCombines)
                    {
                        cmb.X_Default = false;
                    }
                    _context.ProductCombine.UpdateRange(allCombines);
                    await this.CommitAllChanges();
                }
                
                await this.DbSet.AddAsync(entity: entity);
                await this.CommitAllChanges();
                return ResponseModel.Success("ترکیب آماری با موفقیت ایجاد گردید");
            }
            catch (Exception ex)
            {
                return ResponseModel.ServerInternalError(data: ex);
            }
        }
    }
}
