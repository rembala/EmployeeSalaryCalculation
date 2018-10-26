using System.Collections.Generic;
using EmployeeaCalculationSalary.Infrastructure.Data_Access_Layer;
using EmployeeaCalculationSalary.Infrastructure.Helpers;
using EmployeeaCalculationSalary.Infrastructure.View_Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeaCalculationSalary.Infrastructure.Business_Access_Layer;

namespace EmployeeaCalculationSalary.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeesSalaryCalculationContext _bloggingContext;
        private readonly IEmployeeHelper _employeeHelper;
        private readonly IEmployeesService _employeesService;

        public EmployeeController(
            EmployeesSalaryCalculationContext bloggingContext,
            IEmployeeHelper employeeHelper,
            IEmployeesService employeesService)
        {
            _bloggingContext = bloggingContext;
            _employeeHelper = employeeHelper;
            _employeesService = employeesService; 
        }

        [HttpGet("[action]")]
        public IEnumerable<EmployeeListViewModel> GetEmployeeList()
        {
            return _employeeHelper.CreateEmployeeListViewModel();
        }

        [HttpPost("[action]")]
        public void ChangeSatisfactionScore([FromBody]YearsSatisfactionsViewModel yearsSatisfactionsViewModel)
        {
            _employeesService.UpdateEmployeeSatisfactionScore(yearsSatisfactionsViewModel.YearsWorkedId, yearsSatisfactionsViewModel.SatisfactionScore);
        }
    }
}
