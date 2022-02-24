using Northwind.Data.Context;
using Northwind.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Service.Abstract
{
    public interface IEmployeeService : IService<Employee, EmployeeModel>
    {
    }
}
