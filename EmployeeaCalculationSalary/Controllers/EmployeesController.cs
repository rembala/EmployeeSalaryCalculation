using System.Collections.Generic;
using EmployeeaCalculationSalary.Infrastructure.Data_Access_Layer;
using EmployeeaCalculationSalary.Infrastructure.Helpers;
using EmployeeaCalculationSalary.Infrastructure.View_Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeaCalculationSalary.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeesSalaryCalculationContext _bloggingContext;
        private readonly IEmployeeHelper _employeeHelper;

        public EmployeeController(
            EmployeesSalaryCalculationContext bloggingContext,
            IEmployeeHelper employeeHelper)
        {
            _bloggingContext = bloggingContext;
            _employeeHelper = employeeHelper;
        }

        [HttpGet("[action]")]
        public IEnumerable<EmployeeListViewModel> GetEmployeeList()
        {
            return _employeeHelper.CreateEmployeeListViewModel();
        }

    }
}
