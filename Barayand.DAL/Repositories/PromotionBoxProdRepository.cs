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

namespace Barayand.DAL.Repositories
{
    public class PromotionBoxProdRepository : GenericRepository<PerfectProductModel>, IPromotionBoxProdRepository
    {
        private readonly BarayandContext _context;
        public PromotionBoxProdRepository(BarayandContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<PromotionBoxProductsModel> CheckProductCombineExistsInBox(int pid, int wid, int cid)
        {
            try
            {
                var allRelations = await this._context.PromotionBoxProducts.FirstOrDefaultAsync(x => x.X_ProdId == pid && x.X_WarrantyId == wid && x.X_ColorId == cid);
                return allRelations;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<PromotionBoxProductsModel> CheckProductEixstsInBoxs(int pid)
        {
            try
            {
                var allRelations = await this._context.PromotionBoxProducts.FirstOrDefaultAsync(x => x.X_ProdId == pid);
                return allRelations;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ResponseStructure> GetAllRelation(Miscellaneous data)
        {
            try
            {
                var allRelations = this._context.PromotionBoxProducts.Where(x => x.X_SectionId == data.Id).ToList();
                return ResponseModel.Success(data: allRelations);
            }
            catch (Exception ex)
            {
                return ResponseModel.ServerInternalError(data: ex);
            }
        }

        public async Task<ResponseStructure> UpdateRelation(List<PromotionBoxProductsModel> data)
        {
            try
            {
                if (data == null || data.Count() < 1)
                {
                    return ResponseModel.Error("Relation not found");
                }
                var rel = this._context.PromotionBoxProducts.ToList();
                foreach (var item in data)
                {
                    var existsInOtherBoxs = rel.FirstOrDefault(x=>x.X_WarrantyId == item.X_WarrantyId && x.X_ColorId == item.X_ColorId && x.X_SectionId != item.X_SectionId && item.X_ProdId == item.X_ProdId);
                    if(existsInOtherBoxs != null)
                    {
                        data.Remove(item);
                    }
                }
                this._context.PromotionBoxProducts.RemoveRange(rel.Where(x => x.X_SectionId == data.FirstOrDefault().X_SectionId).ToList());
                await this.CommitAllChanges();
                await this._context.PromotionBoxProducts.AddRangeAsync(data);
                await this.CommitAllChanges();
                return ResponseModel.Success("عملیات با موفقیت انجام گردید");
            }
            catch (Exception ex)
            {
                return ResponseModel.ServerInternalError(data: ex);
            }
        }
    }
}
