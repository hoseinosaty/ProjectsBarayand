﻿using Barayand.Models.Entity;
using Barayand.OutModels.Response;
using Barayand.OutModels.Miscellaneous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barayand.DAL.Interfaces
{
    public interface IPRRepository
    {
        Task<ResponseStructure> UpdateRelation(Miscellaneous data);
        Task<ResponseStructure> GetAllRelation(Miscellaneous data);
    }
}
