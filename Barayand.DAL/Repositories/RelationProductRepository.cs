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
    public class RelationProductRepository: GenericRepository<RelationProductRepository>,IPRRepository
    {
        private readonly BarayandContext _context;
        public RelationProductRepository(BarayandContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<ResponseStructure> GetAllRelation(Miscellaneous data)
        {
           try
            {
                var allRelations = this._context.RelatedProduct.Where(x=>x.PR_PId == data.Id).ToList();
                return ResponseModel.Success(data:allRelations);
            }
            catch(Exception ex)
            {
                return ResponseModel.ServerInternalError(data:ex);
            }
        }

        public async Task<ResponseStructure> UpdateRelation(Miscellaneous data)
        {
            try
            {
                List<RelatedProductModel> RawData = new List<RelatedProductModel>();
                var rel = this._context.RelatedProduct.ToList();
                this._context.RelatedProduct.RemoveRange(rel.Where(x=>x.PR_PId == data.Id).ToList());
                await this.CommitAllChanges();
                foreach(var item in data.ProductIds)
                {
                   RawData.Add(new RelatedProductModel() {
                       PR_PId = data.Id,
                       PR_RId = item
                   });
                }
                await this._context.RelatedProduct.AddRangeAsync(RawData);
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
