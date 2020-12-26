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

namespace Barayand.DAL.Repositories
{
    public class PromotionBoxProdRepository : GenericRepository<PerfectProductModel>, IPromotionBoxProdRepository
    {
        private readonly BarayandContext _context;
        public PromotionBoxProdRepository(BarayandContext context) : base(context)
        {
            this._context = context;
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
