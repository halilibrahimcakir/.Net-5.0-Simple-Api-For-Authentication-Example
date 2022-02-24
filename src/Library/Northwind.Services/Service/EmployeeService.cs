using Microsoft.Extensions.DependencyInjection;
using Northwind.Data.Context;
using Northwind.Data.Repository;
using Northwind.Data.UnitOfWork;
using Northwind.Models.Models;
using Northwind.Services.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Service
{
    public class EmployeeService : ServiceBase<Employee, EmployeeModel>, IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Employee> _repository;
        public EmployeeService(IServiceProvider service) : base(service)
        {
            _unitOfWork = service.GetService<IUnitOfWork>();
            _repository = _unitOfWork.GetRepository<Employee>();
        }
    }
}
