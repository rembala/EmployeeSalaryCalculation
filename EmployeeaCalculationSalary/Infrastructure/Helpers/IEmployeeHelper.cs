using EmployeeaCalculationSalary.Infrastructure.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeaCalculationSalary.Infrastructure.Helpers
{
    public interface IEmployeeHelper
    {
        IEnumerable<EmployeeListViewModel> CreateEmployeeListViewModel();
    }
}
