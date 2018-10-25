using EmployeeaCalculationSalary.Infrastructure.Data_Access_Layer;
using EmployeeaCalculationSalary.Infrastructure.Models;
using System.Collections.Generic;

namespace EmployeeaCalculationSalary.Infrastructure.Business_Access_Layer
{
    public class EmployeesService : IEmployeesService
    {
        private readonly EmployeesSalaryCalculationContext _bloggingContext;

        public EmployeesService(EmployeesSalaryCalculationContext bloggingContext)
        {
            _bloggingContext = bloggingContext;
        }

        public IEnumerable<Employees> GetEmployees() => _bloggingContext.Employees;
    }
}
