using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Barayand.DAL.Interfaces;
using Barayand.Models.Entity;
using Barayand.OutModels.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Barayand.Controllers.Cpanel.PromotionBox
{
    [Route("api/cpanel/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionRepository _promotionrepo;
        private readonly IMapper _mapper;
        private readonly ILogger<PromotionController> _logger;
        public PromotionController(IPromotionRepository promotionrepo, IMapper mapper, ILogger<PromotionController> logger)
        {
            _promotionrepo = promotionrepo;
            _mapper = mapper;
            _logger = logger;
        }
        [Route("AddBox")]
        [HttpPost]
        public async Task<IActionResult> AddBox(Barayand.OutModels.Models.PromotionBox pb)
        {
            try
            {
                PromotionBoxModel pbm = (PromotionBoxModel)_mapper.Map<Barayand.OutModels.Models.PromotionBox, PromotionBoxModel>(pb);
                return new JsonResult(await _promotionrepo.Insert(pbm));
            }
            catch(Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError(data:ex));
            }
        }
        [Route("LoadBox/{type}")]
        [HttpPost]
        public async Task<IActionResult> LoadBox(int type = 1)
        {
            try
            {
                var AllPromotions = ((List<PromotionBoxModel>)(await _promotionrepo.GetAll()).Data).ToList();
                return new JsonResult(ResponseModel.Success(data:AllPromotions));
            }
            catch(Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError(data:ex));
            }
        }
    }
}
