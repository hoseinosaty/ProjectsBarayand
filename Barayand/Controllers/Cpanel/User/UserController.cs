using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Barayand.DAL.Interfaces;
using Barayand.Models.Entity;
using Barayand.OutModels.Miscellaneous;
using Barayand.OutModels.Models;
using Barayand.OutModels.Response;
using Barayand.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Barayand.Controllers.Cpanel.User
{
    [Route("api/cpanel/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userrepo;
        private readonly ISmsService _smsService;
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger, IUserRepository userRepository,ISmsService smsService)
        {
            _logger = logger;
            _smsService = smsService;
            _userrepo = userRepository;
        }
        [Route("AddUser")]
        public async Task<ActionResult> AddUser(UserModel um)
        {
            try
            {
                um.U_Role = 1;
                var result = await _userrepo.Insert(um);
                if(result.Status)
                {
                    if(um.U_Phone != "")
                    {
                        await _smsService.SignUp(um.U_Phone,um.surename);
                    }
                }
                return new JsonResult(result);
            }
            catch(Exception ex)
            {
                _logger.LogError("Erro in user controller",ex);
                return new JsonResult(ResponseModel.ServerInternalError(data:ex));
            }
        }
        [Route("UpdateUser")]
        public async Task<ActionResult> UpdateUser(UserModel um)
        {
            try
            {
                um.U_Role = 1;
                return new JsonResult(await _userrepo.UpdateUserAdmin(um));
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro in user controller", ex);
                return new JsonResult(ResponseModel.ServerInternalError(data: ex));
            }
        }
        [Route("SuspendUser")]
        public async Task<ActionResult> SuspendUser(UserModel um)
        {
            try
            {
                um.U_Role = 1;
                return new JsonResult(await _userrepo.SuspendUser(um));
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro in user controller", ex);
                return new JsonResult(ResponseModel.ServerInternalError(data: ex));
            }
        }
        [Route("ActiveUser")]
        public async Task<ActionResult> ActiveUser(UserModel um)
        {
            try
            {
                um.U_Role = 1;
                return new JsonResult(await _userrepo.ActiveUser(um));
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro in user controller", ex);
                return new JsonResult(ResponseModel.ServerInternalError(data: ex));
            }
        }
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult> Login(UserModel um)
        {
            try
            {
                var login = await _userrepo.UserLogin(um);
                if(!login.Status)
                {
                    return new JsonResult(login);
                }
                var token = ((UserModel)login.Data).Token;
                Response.Cookies.Append("BarayandCPUser", token);
                return new JsonResult(ResponseModel.Success("Login successfull.",new {
                    un = ((UserModel)login.Data).U_Name,
                    uln = ((UserModel)login.Data).U_Family,
                    ue = ((UserModel)login.Data).U_Email,
                    up = ((UserModel)login.Data).U_Phone,
                    ua = ((UserModel)login.Data).U_Avatar
                }));
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in user login",ex);
                return new JsonResult(ResponseModel.ServerInternalError(data:ex));
            }
        }
        [Route("LoadUsers")]
        public async Task<ActionResult> LoadUsers()
        {
            try
            {
                return new JsonResult(await _userrepo.GetAllAdmins());
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro in user controller", ex);
                return new JsonResult(ResponseModel.ServerInternalError(data: ex));
            }
        }
    }
}
