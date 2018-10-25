using EmployeeaCalculationSalary.Infrastructure.Models;
using System.Collections.Generic;

namespace EmployeeaCalculationSalary.Infrastructure.Business_Access_Layer
{
    public interface IManagerService
    {
        IEnumerable<Managers> GetManagers();
        Managers GetManagerByEmployeeId(Employees employees);
    }
}
