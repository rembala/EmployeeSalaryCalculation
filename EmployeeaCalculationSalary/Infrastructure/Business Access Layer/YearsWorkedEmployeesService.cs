using EmployeeaCalculationSalary.Infrastructure.Data_Access_Layer;
using EmployeeaCalculationSalary.Infrastructure.Models;
using EmployeeaCalculationSalary.Infrastructure.View_Models;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<YearsSatisfactionsViewModel> GetYearsSatisfacions(Employees employees)
        {
            var employeesYearsWorked = _bloggingContext.YearsWorkedEmployees.Where(yearsWorked => yearsWorked.EmployeeId == employees.EmployeeId);

            var employeeSatisfactions = _satisfactionScoresService.GetSatisfactionScores();

            return from empYearWorked in employeesYearsWorked
                   join satisf in employeeSatisfactions on empYearWorked.SatisfactionScoreId equals satisf.SatisfactionScoreId
                   select new YearsSatisfactionsViewModel()
                   {
                       EmployeeId = empYearWorked.EmployeeId,
                       SatisfactionScore = satisf.SatisfactionScore,
                       YearsWorked = empYearWorked.YearsWorked
                   };

        }
    }
}
