﻿using Barayand.Models.Entity;
using Barayand.OutModels.Miscellaneous;
using Barayand.OutModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barayand.DAL.Interfaces
{
    public interface IFestivalRepository:IPublicMethodRepsoitory<FestivalOfferModel>
    {
        public Task<ResponseStructure> InsertCollation(FestivalCreationModel data);
    }
}
