using EmployeeaCalculationSalary.Infrastructure.Data_Access_Layer;
using EmployeeaCalculationSalary.Infrastructure.Models;
using System.Collections.Generic;

namespace EmployeeaCalculationSalary.Infrastructure.Business_Access_Layer
{
    public class YearsWorkedEmployeesService : IYearsWorkedEmployeesService
    {
        private readonly EmployeesSalaryCalculationContext _bloggingContext;
        private readonly ISatisfactionScoresService _satisfactionScoresService;

        public YearsWorkedEmployeesService(
            EmployeesSalaryCalculationContext bloggingContext,
            ISatisfactionScoresService satisfactionScoresService)
        {
            _bloggingContext = bloggingContext;
            _satisfactionScoresService = satisfactionScoresService;
        }

        public IEnumerable<YearsWorkedEmployees> GetYearsWorkedEmployees() => _bloggingContext.YearsWorkedEmployees;
    }
}
