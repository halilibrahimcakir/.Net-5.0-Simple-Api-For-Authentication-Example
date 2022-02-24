using Northwind.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Northwind.Models.TokenModel
{
    public class TokenModel
    {
        [JsonIgnore]
        public EmployeeModel LoginUser { get; set; }
        public object AccessToken { get; set; }
    }
}
