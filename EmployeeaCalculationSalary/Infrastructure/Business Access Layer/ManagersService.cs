using EmployeeaCalculationSalary.Infrastructure.Data_Access_Layer;
using EmployeeaCalculationSalary.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeaCalculationSalary.Infrastructure.Business_Access_Layer
{
    public class ManagersService : IManagerService
    {
        private readonly EmployeesSalaryCalculationContext _bloggingContext;
        private readonly IEmployeesService _employeesService;

        public ManagersService(
            EmployeesSalaryCalculationContext bloggingContext,
            IEmployeesService employeesService)
        {
            _bloggingContext = bloggingContext;
            _employeesService = employeesService;
        }

        public IEnumerable<Managers> GetManagers() => _bloggingContext.Managers;

        public Managers GetManagerByEmployeeId(Employees employees)
            
          => _bloggingContext.Managers.Where(pr => pr.ManagerId == employees.ManagerId).FirstOrDefault();

    }
}
