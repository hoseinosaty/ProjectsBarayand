using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Barayand.DAL.Interfaces;
using Barayand.DAL.Repositories;
using Barayand.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Barayand.OutModels.Response;
using Barayand.OutModels.Models;
using Barayand.OutModels.Miscellaneous;


namespace Barayand.Controllers.Cpanel.Product
{
    [Route("api/cpanel/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPublicMethodRepsoitory<ProductModel> _repository;
        private readonly IPRRepository _productrelationrepo;
        public ProductController(IMapper mapper, IPublicMethodRepsoitory<ProductModel> repository, IPRRepository productrelationrepo)
        {
            this._repository = repository;
            this._productrelationrepo = productrelationrepo;
            this._mapper = mapper;
        }
        [Route("AddProduct")]
        [HttpPost]
        public async Task<ActionResult> AddProduct(OutModels.Models.Product product)
        {
            try
            {
                ProductModel b = (ProductModel)_mapper.Map<OutModels.Models.Product, ProductModel>(product);
                return new JsonResult(await this._repository.Insert(b));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [Route("UpdateProduct")]
        [HttpPost]
        public async Task<ActionResult> UpdateProduct(OutModels.Models.Product product)
        {
            try
            {
                ProductModel b = (ProductModel)_mapper.Map<OutModels.Models.Product, ProductModel>(product);
                return new JsonResult(await this._repository.Update(b));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [Route("ActiveProduct")]
        [HttpPost]
        public async Task<ActionResult> ActiveProduct(OutModels.Models.Product product)
        {
            try
            {
                int id = product.P_Id;
                if (id == 0)
                {
                    return new JsonResult(ResponseModel.Error("موردی یافت نشد"));
                }
                return new JsonResult(await this._repository.LogicalAvailable(id, true));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [Route("DisableProduct")]
        [HttpPost]
        public async Task<ActionResult> DisableProduct(OutModels.Models.Product product)
        {
            try
            {
                int id = product.P_Id;
                if (id == 0)
                {
                    return new JsonResult(ResponseModel.Error("موردی یافت نشد"));
                }
                return new JsonResult(await this._repository.LogicalAvailable(id, false));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [Route("DeleteProduct")]
        [HttpPost]
        public async Task<ActionResult> DeleteProduct(OutModels.Models.Product product)
        {
            try
            {
                int id = product.P_Id;
                if (id == 0)
                {
                    return new JsonResult(ResponseModel.Error("موردی یافت نشد"));
                }
                return new JsonResult(await this._repository.LogicalDelete(id));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [Route("LoadProducts/{catid}/{lang}")]
        [HttpPost]
        public async Task<ActionResult> LoadProducts(string lang,int catid = 0)
        {
            try
            {
                List<ProductModel> data = (List<ProductModel>)(await this._repository.GetAll()).Data;
                List<OutModels.Models.Product> result = _mapper.Map<List<ProductModel>, List<OutModels.Models.Product>>(data.Where(x=>x.P_EndLevelCatId == catid && x.Lang == lang).OrderBy(x=>x.Created_At).ToList());
                return new JsonResult(ResponseModel.Success("PRODUCTS_LIST_RETURNED", result));
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError(data:ex));
            }
        }
        [Route("LoadProductsDeletePid/{catid}/{pid}")]
        [HttpPost]
        public async Task<ActionResult> LoadProducts(int catid = 0,int pid = 0)
        {
            try
            {
                List<ProductModel> data = (List<ProductModel>)(await this._repository.GetAll()).Data;
                List<OutModels.Models.Product> result = _mapper.Map<List<ProductModel>, List<OutModels.Models.Product>>(data.Where(x => x.P_EndLevelCatId == catid && x.P_Id != pid).ToList());
                var relations =((List<RelatedProductModel>)(await _productrelationrepo.GetAllRelation(new Miscellaneous() {Id = pid })).Data);
                List<OutModels.Models.Product> Relations = new List<OutModels.Models.Product>();
                foreach(var item in result)
                {
                    if(relations.Count(x=>x.PR_PId == pid && x.PR_RId == item.P_Id) > 0)
                    {
                        Relations.Add(item);
                    }
                }

                return new JsonResult(ResponseModel.Success("PRODUCTS_LIST_RETURNED", new {Products = result,Relations = Relations }));
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError(data: ex));
            }
        }
        ////////
        [Route("AddProductRelation")]
        [HttpPost]
        public async Task<ActionResult> AddProductRelation(Miscellaneous data)
        {
            try
            {
                return new JsonResult(await _productrelationrepo.UpdateRelation(data));
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError(data: ex));
            }
        }
        [Route("GetProductRelation")]
        [HttpPost]
        public async Task<ActionResult> GetProductRelation(Miscellaneous data)
        {
            try
            {
                return new JsonResult(await _productrelationrepo.GetAllRelation(data));
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError(data: ex));
            }
        }
    }
}