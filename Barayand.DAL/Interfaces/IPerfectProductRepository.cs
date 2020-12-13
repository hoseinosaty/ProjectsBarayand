﻿using Barayand.Models.Entity;
using Barayand.OutModels.Response;
using Barayand.OutModels.Miscellaneous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Barayand.DAL.Interfaces
{
    public interface IPerfectProductRepository
    {
        Task<ResponseStructure> UpdateRelation(List<PerfectProductModel> data);
        Task<ResponseStructure> GetAllRelation(Miscellaneous data);
    }
}
