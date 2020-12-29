using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barayand.DAL.Interfaces;
using Barayand.Models.Entity;
using Barayand.Services.Interfaces;
using Gbook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gbook.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IPublicMethodRepsoitory<GalleryCategoryModel> _gallerycatrepo;
        private readonly IPublicMethodRepsoitory<ImageGalleryModel> _imagerepo;
        private readonly ICommentRepository _commentRepository;
        private readonly IRateRepository _rateRepository;
        private readonly IPublicMethodRepsoitory<VideoGalleryModel> _videorepo;
        private readonly ILogger<GalleryController> _logger;
        private readonly ILocalizationService _lang;
        public GalleryController(IPublicMethodRepsoitory<GalleryCategoryModel> gallerycatrepo, IPublicMethodRepsoitory<ImageGalleryModel> imagerepo, IPublicMethodRepsoitory<VideoGalleryModel> videorepo, ILogger<GalleryController> logger, ICommentRepository commentRepository, IRateRepository rateRepository, ILocalizationService lang)
        {
            this._gallerycatrepo = gallerycatrepo;
            this._logger = logger;
            this._imagerepo = imagerepo;
            this._videorepo = videorepo;
            this._commentRepository = commentRepository;
            this._rateRepository = rateRepository;
            _lang = lang;
        }

        [Route("ImageGallery/{page?}")]
        public async Task<IActionResult> Index(int page = 1)
        {

            try
            {
                var galleris = ((List<GalleryCategoryModel>)(await _gallerycatrepo.GetAll()).Data).Where(x=>x.GC_Status && x.GC_Type == 1 && x.GC_IsDeleted == false && x.Lang == _lang.GetLang()).OrderBy(x=>x.GC_SortField).ToList();
                int pageSize = 10;
                int totalPage = (int)Math.Ceiling((double)galleris.Count() / pageSize);
                galleris = galleris.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                ViewBag.CurrentPage = page;
                ViewBag.TotalPages = totalPage;
                return View(galleris);
            }
            catch(Exception ex)
            {
                _logger.LogError("ErrorGalleryController",ex);
                return View(new List<GalleryCategoryModel>());
            }
        }
        [Route("ImageGallery/{cat}/{title}/{page?}")]
        public async Task<IActionResult> LoadImagesByCat(int cat,int page = 1,string title = null)
        {

            try
            {
                var existsGCat = await _gallerycatrepo.GetById(cat);
                if(existsGCat == null)
                {
                    return RedirectToAction("Index","Home");
                }
                ViewBag.PageSeo = existsGCat.GC_Seo;
                var galleris = ((List<ImageGalleryModel>)(await _imagerepo.GetAll()).Data).Where(x => x.IG_Status && x.IG_CatId == cat && x.Lang == _lang.GetLang()).OrderBy(x => x.IG_SortField).ToList();
                int pageSize = 10;
                int totalPage = (int)Math.Ceiling((double)galleris.Count() / pageSize);
                galleris = galleris.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                ViewBag.CurrentPage = page;
                ViewBag.TotalPages = totalPage;
                ViewBag.Cat = cat;
                return View(galleris);
            }
            catch (Exception ex)
            {
                _logger.LogError("ErrorGalleryController", ex);
                return View(new List<ImageGalleryModel>());
            }
        }

        [Route("VideoGallery/{page?}")]
        public async Task<IActionResult> VideoGalleryCategories(bool Isajax=false,int page=1)
        {
            try
            {
                var galleris = ((List<GalleryCategoryModel>)(await _gallerycatrepo.GetAll()).Data).Where(x => x.GC_Status&&x.GC_Type==2).OrderBy(x => x.GC_SortField).ToList();
                Paging paging = new Paging();
                paging.TotalCount = galleris.Count();
                paging.PageSize = 12;
                paging.CurrentPage = page;
                paging.TotalPages = (int)Math.Ceiling(paging.TotalCount / (double)paging.PageSize);
                ViewBag.paging = paging;
                var items = galleris.Skip((paging.CurrentPage - 1) * paging.PageSize).Take(paging.PageSize).ToList();
                if (Isajax)
                {
                    return View("_GalleryList",items);
                }
                return View(items);
            }
            catch (Exception ex)
            {
                _logger.LogError("ErrorGalleryController", ex);
                return View(new List<GalleryCategoryModel>());
            }
        }

      ////Video Gallery
     
        //public async Task<IActionResult> VideoGalleryCategories(int cat = 0,int page = 1,string title=null)
        //{

        //    try
        //    {
        //        var galleris = ((List<VideoGalleryModel>)(await _videorepo.GetAll()).Data).Where(x => x.VG_Status && x.Lang == _lang.GetLang()).OrderBy(x => x.VG_SortField).ToList();
        //        var existsGCat = await _gallerycatrepo.GetById(cat);
        //        if (existsGCat != null)
        //        {
        //            galleris = galleris.Where(x => x.VG_CatId == cat).ToList();
        //            ViewBag.PageSeo = existsGCat.GC_Seo;
        //        }
               
        //        int pageSize = 10;
        //        int totalPage = (int)Math.Ceiling((double)galleris.Count() / pageSize);
        //        galleris = galleris.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //        ViewBag.CurrentPage = page;
        //        ViewBag.TotalPages = totalPage;
        //        ViewBag.Cat = cat;
        //        ViewBag.Categories = ((List<GalleryCategoryModel>)(await _gallerycatrepo.GetAll()).Data).Where(x => x.GC_Status && x.GC_Type == 2 && x.Lang == _lang.GetLang()).OrderBy(x => x.GC_SortField).ToList();
        //        return View(galleris);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("ErrorGalleryController", ex);
        //        return View(new List<GalleryCategoryModel>());
        //    }
        //}
        [Route("VideoGallery/Detail/{id}/{title}")]
        public async Task<IActionResult> VideoDetail(int id, string title = null)
        {

            try
            {
                var existsVideo = await _videorepo.GetById(id);
                if (existsVideo == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.PageSeo = existsVideo.VG_Seo;
                existsVideo.Comments = await _commentRepository.AcceptedComments(existsVideo.VG_Id, 4);
                existsVideo.Rate = (int)await _rateRepository.CalulateRate(existsVideo.VG_Id,4);
                return View(existsVideo);
            }
            catch (Exception ex)
            {
                _logger.LogError("ErrorGalleryController", ex);
                return View(new List<VideoGalleryModel>());
            }
        }
    }
}
