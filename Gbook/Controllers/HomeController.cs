using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Gbook.Models;
using Barayand.DAL.Interfaces;
using Barayand.Models.Entity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Options;
using AutoMapper.Configuration;
using Barayand.Services.Interfaces;
using Newtonsoft.Json;
using Barayand.OutModels.Miscellaneous;
using Barayand.Common.Services;
using Wangkanai.Detection.Services;
using Wangkanai.Detection.Models;
using Barayand.OutModels.Response;

namespace Gbook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IPublicMethodRepsoitory<DynamicPagesContent> _dynamicrepeo;
        private readonly IDetectionService _detectionService;
        private readonly IPromotionRepository _promotionrepo;

        public HomeController(ILogger<HomeController> logger, IPublicMethodRepsoitory<DynamicPagesContent> dynamicrepeo, IDetectionService detectionService, IPromotionRepository promotionrepo)
        {
            _logger = logger;
            _dynamicrepeo = dynamicrepeo;
            _detectionService = detectionService;
            _promotionrepo = promotionrepo;
        }

        string currentLanguage;

        public async Task<IActionResult> Index()
        {
            ViewBag.staticBox = await _promotionrepo.GetByType(1);
            ViewBag.moveableBox = await _promotionrepo.GetByType(2);
            return View();
        }
        [Route("contactus")]
        [Route("Pages/cu/{title?}")]
        public async Task<IActionResult> ContactUs(string title = "")
        {
            try
            {
                var page = ((List<DynamicPagesContent>)(await _dynamicrepeo.GetAll()).Data).FirstOrDefault(x=>x.PageName == "ContactUs");
                if(page == null)
                {
                    return RedirectToAction("Index","Home");
                }
                ViewBag.PageSeo = page.PageSeo;
                ViewBag.Data = JsonConvert.DeserializeObject<ContactUsData>(page.PageOtherSetting);
                var seo = Barayand.Common.Services.UtilesService.ParseSeoData(page.PageSeo);
                ViewBag.PGNAME = seo.title;
                return View(page);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in main controller action index", ex);
                return null;
            }
        }
        [Route("aboutus")]
        [Route("Pages/au/{title?}")]
        public async Task<IActionResult> AboutUs(string title = "")
        {
            try
            {
                var page = ((List<DynamicPagesContent>)(await _dynamicrepeo.GetAll()).Data).FirstOrDefault(x => x.PageName == "AboutUs");
                if (page == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.PageSeo = page.PageSeo;
                var seo = Barayand.Common.Services.UtilesService.ParseSeoData(page.PageSeo);
                ViewBag.PGNAME = seo.title;
                return View(page);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in main controller action index", ex);
                return null;
            }
        }
        [Route("Pages/{url?}")]
        public async Task<IActionResult> Pages(string url = "")
        {
            try
            {
                DynamicPagesContent page = null;
                foreach (var p in ((List<DynamicPagesContent>)(await _dynamicrepeo.GetAll()).Data))
                {
                    if(p.PageSeo != null )
                    {
                        var seo = Barayand.Common.Services.UtilesService.ParseSeoData(p.PageSeo);
                        if(seo != null && seo.url != null && seo.url == url)
                        {
                            page = p;
                        }
                    }
                }
                if (page == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.PageSeo = page.PageSeo;
                var s = Barayand.Common.Services.UtilesService.ParseSeoData(page.PageSeo);
                ViewBag.PGNAME = s.title;
                return View(page);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in main controller action index", ex);
                return null;
            }
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
