using Northwind.Models.ResponseModel;
using Northwind.Models.TokenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Token
{
    public interface ITokenService
    {
        ResponseModel<TokenModel> Login(LoginModel login);
    }
}
