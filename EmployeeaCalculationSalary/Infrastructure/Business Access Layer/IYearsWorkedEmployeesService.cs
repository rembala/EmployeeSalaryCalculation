using EmployeeaCalculationSalary.Infrastructure.Models;
using EmployeeaCalculationSalary.Infrastructure.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeaCalculationSalary.Infrastructure.Business_Access_Layer
{
    public interface IYearsWorkedEmployeesService
    {
        IEnumerable<YearsWorkedEmployees> GetYearsWorkedEmployees();

        IEnumerable<YearsSatisfactionsViewModel> GetEmployeeYearsSatisfacions(Employees employees);
    }
}
