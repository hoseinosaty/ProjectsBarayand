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
    public class SetProductRepository : GenericRepository<PerfectProductModel>, ISetProductRepository
    {
        private readonly BarayandContext _context;
        public SetProductRepository(BarayandContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<ResponseStructure> GetAllRelation(Miscellaneous data)
        {
            try
            {
                var allRelations = this._context.SetProduct.Where(x => x.X_MainProdId == data.Id).ToList();
                return ResponseModel.Success(data: allRelations);
            }
            catch (Exception ex)
            {
                return ResponseModel.ServerInternalError(data: ex);
            }
        }

        public async Task<ResponseStructure> UpdateRelation(List<SetProductsModel> data)
        {
            try
            {
                if (data == null || data.Count() < 1)
                {
                    return ResponseModel.Error("Relation not found");
                }
                var rel = this._context.SetProduct.ToList();
                this._context.SetProduct.RemoveRange(rel.Where(x => x.X_MainProdId == data.FirstOrDefault().X_MainProdId).ToList());
                await this.CommitAllChanges();
                await this._context.SetProduct.AddRangeAsync(data);
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
