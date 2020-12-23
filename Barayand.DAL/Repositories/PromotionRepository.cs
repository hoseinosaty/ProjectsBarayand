using Barayand.DAL.Context;
using Barayand.DAL.Interfaces;
using Barayand.Models.Entity;
using Barayand.OutModels.Models;
using Barayand.OutModels.Response;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Barayand.DAL.Repositories
{
    public class PromotionRepository : GenericRepository<PromotionBoxModel>, IPromotionRepository
    {
        private readonly BarayandContext _context;
        public PromotionRepository(BarayandContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<PromotionBoxModel>> GetByType(int Type)
        {
            try
            {
                var AllPromotions = ((List<PromotionBoxModel>)(await GetAll()).Data).Where(x=>x.B_Type == Type).ToList();
                return AllPromotions;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<PromotionBoxModel> GetBySectionId(int Secid)
        {
            try
            {
                var AllPromotions = ((List<PromotionBoxModel>)(await GetAll()).Data).FirstOrDefault(x => x.B_SectionId == Secid);
                return AllPromotions;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<ResponseStructure> Insert(PromotionBoxModel entity)
        {
            try
            {
                var checkExists = await GetBySectionId(entity.B_SectionId);
                if(checkExists != null)
                {
                    checkExists.B_LoadType = entity.B_LoadType;
                    checkExists.B_Link = entity.B_Link;
                    checkExists.B_Image = entity.B_Image;
                    checkExists.B_Seo = entity.B_Seo;
                    checkExists.B_Title = entity.B_Title;
                    checkExists.Updated_At = DateTime.Now;
                    return await this.Update(checkExists);
                }
                else
                {
                    this._context.PromotionBoxs.Add(entity);
                    await this._context.SaveChangesAsync();
                    return ResponseModel.Success("باکس مورد نظر با موفقیت بروزرسانی گردید");
                }
            }
            catch (Exception ex)
            {
                return ResponseModel.ServerInternalError(data: ex);
            }
        }
        public Task<ResponseStructure> LogicalAvailable(object id, bool newState)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseStructure> LogicalDelete(object id)
        {
            throw new NotImplementedException();
        }
    }
}
