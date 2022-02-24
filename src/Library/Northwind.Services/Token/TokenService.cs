using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Northwind.Models.ResponseModel;
using Northwind.Models.TokenModel;
using Northwind.Services.Service.Abstract;
using System;
using System.Linq;

namespace Northwind.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IEmployeeService _employeeService;
        public TokenService(IConfiguration configuration, IEmployeeService employeeService)
        {
            _configuration = configuration;
            _employeeService = employeeService;
        }

        public ResponseModel<TokenModel> Login(LoginModel login)
        {
            var user = _employeeService.GetAll().Where(x => x.EmployeeId == login.Id && x.FirstName == login.Name).FirstOrDefault();

            if (user != null)
            {
                var token = new TokenManagement(_configuration).CreateAccessToken(user);

                var userToken = new TokenModel()
                {
                    LoginUser = user,
                    AccessToken = token
                };

                return new ResponseModel<TokenModel>
                {
                    Message = "Token is success!",
                    StatusCode = StatusCodes.Status200OK,
                    Data = userToken
                };
            }
            else
            {
                return new ResponseModel<TokenModel>
                {
                    Message = "UserCode or Password is wrong.",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };
            }
        }
    }
}
