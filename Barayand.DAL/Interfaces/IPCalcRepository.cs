using Barayand.Models.Entity;
using Barayand.OutModels.Miscellaneous;
using Barayand.OutModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Barayand.DAL.Interfaces
{
    public interface IPCalcRepository
    {
        //Task<PriceModel> CalculateBookPrice(int pid,string lang);
        Task<ProductCombineModel> CalculateProductPrice(int pid);
    }
}
