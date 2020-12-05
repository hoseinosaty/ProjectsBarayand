using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barayand.Common.Constants;
using Barayand.DAL.Interfaces;
using Barayand.Models.Entity;
using Barayand.OutModels.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barayand.Controllers.BaseSetting
{
    [Route("api/cpanel/basesetting/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IPublicMethodRepsoitory<Province> _provincerepo;
        private readonly IPublicMethodRepsoitory<States> _staterepo;
        public BaseController(IPublicMethodRepsoitory<Province> provincerepo, IPublicMethodRepsoitory<States> staterepo)
        {
            _provincerepo = provincerepo;
            _staterepo = staterepo;
        }

        /// <summary>
        /// Get Max Level Count For Deny User - Product Category Creation Page
        /// </summary>
        /// <returns></returns>
        [Route("GetMaxLevel/{type?}")]
        [HttpPost]
        public async Task<ActionResult> GetMaxLevel(int type = 1)//Default Physical
        {
            try
            {
                type = type == 0 ? 1 : type;
                int MAX = 0;
                if (type == 1)
                {
                    MAX = Constants.MAX_CAT_LEVEL;
                }
                else if (type == 2)
                {
                    MAX = Constants.MAX_DIGITAL_CAT_LEVEL;
                }
                else if (type == 3)
                {
                    MAX = Constants.MAX_TRAINING_CAT_LEVEL;
                }
                return new JsonResult(ResponseModel.Success(data:MAX));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [Route("LoadProvinces")]
        [HttpPost]
        public async Task<ActionResult> LoadProvinces()
        {
            try
            {
                return new JsonResult(await _provincerepo.GetAll());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [Route("LoadStates/{prov?}")]
        [HttpPost]
        public async Task<ActionResult> LoadStates(int prov = 0)
        {
            try
            {
                var AllStates = ((List<States>)(await _staterepo.GetAll()).Data);
                if(prov != 0)
                {
                    AllStates = AllStates.Where(x=>x.Province == prov).ToList();
                }
                return new JsonResult(ResponseModel.Success(data:AllStates));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}