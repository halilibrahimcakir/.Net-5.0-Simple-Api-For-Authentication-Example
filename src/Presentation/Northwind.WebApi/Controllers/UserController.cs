using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models.ResponseModel;
using Northwind.Models.TokenModel;
using Northwind.Services.Token;
using System;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ITokenService _tokenService;
        public UserController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public ResponseModel<TokenModel> Login([FromBody]LoginModel login)
        {
            try
            {
                return _tokenService.Login(login);
            }
            catch (Exception ex)
            {
                return new ResponseModel<TokenModel>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }
    }
}
