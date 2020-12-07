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
        private readonly IPublicMethodRepsoitory<ProductCombineModel> _combinerepository;
        private readonly IPublicMethodRepsoitory<WarrantyModel> _warrantyrepo;
        private readonly IPublicMethodRepsoitory<ColorModel> _colorrepo;
        private readonly IPRRepository _productrelationrepo;
        public ProductController(IMapper mapper, IPublicMethodRepsoitory<ProductModel> repository, IPRRepository productrelationrepo, IPublicMethodRepsoitory<ProductCombineModel> combinerepo, IPublicMethodRepsoitory<WarrantyModel> warrantyrepo, IPublicMethodRepsoitory<ColorModel> colorrepo)
        {
            this._repository = repository;
            this._productrelationrepo = productrelationrepo;
            this._combinerepository = combinerepo;
            this._warrantyrepo = warrantyrepo;
            this._colorrepo = colorrepo;
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
        public async Task<ActionResult> LoadProducts(string lang = null,int catid = 0)
        {
            try
            {
                List<ProductModel> data = (List<ProductModel>)(await this._repository.GetAll()).Data;
                List<OutModels.Models.Product> result = new List<OutModels.Models.Product>();
                if(catid != 0)
                {
                    result = _mapper.Map<List<ProductModel>, List<OutModels.Models.Product>>(data.Where(x => x.P_EndLevelCatId == catid).OrderBy(x => x.Created_At).ToList());
                }
                else
                {
                    result = _mapper.Map<List<ProductModel>, List<OutModels.Models.Product>>(data.OrderBy(x => x.Created_At).ToList());
                }
                return new JsonResult(ResponseModel.Success("PRODUCTS_LIST_RETURNED", result));
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError(data:ex));
            }
        }
        [Route("LoadProductsDeletePid/{pid}/{page?}/{count?}/{title?}/{code?}")]
        [HttpPost]
        public async Task<ActionResult> LoadProducts(int page = 1,int count = 5,int pid = 0,string title = null,string code = null)
        {
            try
            {
                List<ProductModel> data = (List<ProductModel>)(await this._repository.GetAll()).Data;
                List<OutModels.Models.Product> result = _mapper.Map<List<ProductModel>, List<OutModels.Models.Product>>(data.Where(x => x.P_Id != pid).ToList());
                
                if(title != null)
                {
                    result = result.Where(x=>x.P_Title.Contains(title,StringComparison.InvariantCultureIgnoreCase) || x.P_Description.Contains(title, StringComparison.InvariantCultureIgnoreCase)).ToList();
                }
                if(code != null)
                {
                    result = result.Where(x => x.P_Code.Contains(code, StringComparison.InvariantCultureIgnoreCase)).ToList();
                }

                return new JsonResult(ResponseModel.Success("PRODUCTS_LIST_RETURNED", new {Products = result }));
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

        ////
        [Route("AddProductCombine")]
        [HttpPost]
        public async Task<ActionResult> AddProductCombine(OutModels.Models.ProductCombine product)
        {
            try
            {
                ProductCombineModel b = (ProductCombineModel)_mapper.Map<OutModels.Models.ProductCombine, ProductCombineModel>(product);
                return new JsonResult(await this._combinerepository.Insert(b));
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError(data:ex));
            }
        }
        [Route("UpdateProductCombine")]
        [HttpPost]
        public async Task<ActionResult> UpdateProductCombine(OutModels.Models.ProductCombine product)
        {
            try
            {
                ProductCombineModel b = (ProductCombineModel)_mapper.Map<OutModels.Models.ProductCombine, ProductCombineModel>(product);
                return new JsonResult(await this._combinerepository.Update(b));
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError(data: ex));
            }
        }
        [Route("ActiveProductCombine")]
        [HttpPost]
        public async Task<ActionResult> ActiveProductCombine(OutModels.Models.ProductCombine product)
        {
            try
            {
                int id = product.X_Id;
                if (id == 0)
                {
                    return new JsonResult(ResponseModel.Error("موردی یافت نشد"));
                }
                return new JsonResult(await this._combinerepository.LogicalAvailable(id, true));
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError(data: ex));
            }
        }
        [Route("DisableProductCombine")]
        [HttpPost]
        public async Task<ActionResult> DisableProductCombine(OutModels.Models.ProductCombine product)
        {
            try
            {
                int id = product.X_Id;
                if (id == 0)
                {
                    return new JsonResult(ResponseModel.Error("موردی یافت نشد"));
                }
                return new JsonResult(await this._combinerepository.LogicalAvailable(id, false));
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError(data: ex));
            }
        }
        [Route("DeleteProductCombine")]
        [HttpPost]
        public async Task<ActionResult> DeleteProductCombine(OutModels.Models.ProductCombine product)
        {
            try
            {
                int id = product.X_Id;
                if (id == 0)
                {
                    return new JsonResult(ResponseModel.Error("موردی یافت نشد"));
                }
                return new JsonResult(await this._combinerepository.LogicalDelete(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError(data: ex));
            }
        }
        [Route("LoadProductCombine")]
        [HttpPost]
        public async Task<ActionResult> LoadProductCombine(OutModels.Models.ProductCombine product)
        {
            try
            {
                var AllCombines = ((List<ProductCombineModel>)(await _combinerepository.GetAll()).Data).Where(x => !x.X_IsDeleted && x.X_ProductId == product.X_ProductId).OrderByDescending(x=>x.Created_At).ToList(); 
                foreach(var item in AllCombines)
                {
                    item.WarrantyModel = await _warrantyrepo.GetById(item.X_WarrantyId);
                    item.ColorDetail = await _colorrepo.GetById(item.X_ColorId);
                }
                return new JsonResult(ResponseModel.Success(data:AllCombines));
            }
            catch (Exception ex)
            {
                return new JsonResult(ResponseModel.ServerInternalError(data: ex));
            }
        }
    }
}