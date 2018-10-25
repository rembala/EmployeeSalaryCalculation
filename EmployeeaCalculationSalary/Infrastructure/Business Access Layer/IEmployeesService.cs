using EmployeeaCalculationSalary.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeaCalculationSalary.Infrastructure.Business_Access_Layer
{
    public interface IEmployeesService
    {
        IEnumerable<Employees> GetEmployees();
    }
}
