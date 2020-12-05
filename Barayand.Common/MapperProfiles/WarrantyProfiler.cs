using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barayand.Models;
using Barayand.OutModels;
using Barayand.Models.Entity;
using Barayand.OutModels.Models;
namespace Barayand.Common.MapperProfiles
{
    public class WarrantyProfiler : Profile
    {
        public WarrantyProfiler()
        {
            CreateMap<WarrantyModel, OutModels.Models.Warranty>().IncludeAllDerived().ReverseMap();
        }
    }
}
