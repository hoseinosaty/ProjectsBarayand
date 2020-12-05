﻿using Barayand.OutModels.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Barayand.Services.Interfaces
{
    public interface ISmsService : IMessageService
    {
        public string APIKey { get; set; }
        public string PatternId { get; set; }
        
        Task<ResponseStructure> SignUp(string phone,string userName);
        Task<ResponseStructure> OrderAlert(string phone,string invoiceid,string amount);
        Task<ResponseStructure> WalletAllert(string phone,int type,string amount);
        Task<ResponseStructure> OfflineRequest(string phone,string code,string state);

    }
}
