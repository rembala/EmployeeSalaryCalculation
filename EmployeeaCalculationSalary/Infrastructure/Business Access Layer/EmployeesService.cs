using EmployeeaCalculationSalary.Infrastructure.Data_Access_Layer;
using EmployeeaCalculationSalary.Infrastructure.Models;
using EmployeeaCalculationSalary.Infrastructure.View_Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeaCalculationSalary.Infrastructure.Business_Access_Layer
{
    public class EmployeesService : IEmployeesService
    {
        private readonly EmployeesSalaryCalculationContext _bloggingContext;
        private readonly ISatisfactionScoresService _satisfactionScoresService;
        private readonly IYearsWorkedEmployeesService _yearsWorkedEmployeesService;

        public EmployeesService(
            EmployeesSalaryCalculationContext bloggingContext,
            ISatisfactionScoresService satisfactionScoresService,
            IYearsWorkedEmployeesService yearsWorkedEmployeesService)
        {
            _bloggingContext = bloggingContext;
            _satisfactionScoresService = satisfactionScoresService;
            _yearsWorkedEmployeesService = yearsWorkedEmployeesService;
        }

        public IEnumerable<Employees> GetEmployees() => _bloggingContext.Employees;

        public EmployeeMaxYearViewModel GetEmmployeeLastYearSatisfaction(IEnumerable<YearsSatisfactionsViewModel> yearsSatisfactions)
        {
            return yearsSatisfactions.OrderByDescending(employee => int.Parse(employee.YearsWorked))
                .Select(employeeMax =>
                    new EmployeeMaxYearViewModel()
                    {
                        YearsWorkedId = employeeMax.YearsWorkedId,
                        MaxYear = employeeMax.YearsWorked,
                        SatisfactionScore = employeeMax.SatisfactionScore
                    }
                    ).FirstOrDefault();
        }

        public void UpdateEmployeeSatisfactionScore(int yearsWorkedId, int satisfactionScore)
        {
            var satisfactionScoreEmployee = _satisfactionScoresService.GetSatisfactionScores()
                .FirstOrDefault(satisfaction => satisfaction.SatisfactionScore == satisfactionScore);

            var employeeYearsWorked = _bloggingContext.YearsWorkedEmployees.FirstOrDefault(employee => employee.YearsWorkedId == yearsWorkedId);

            employeeYearsWorked.SatisfactionScoreId = satisfactionScoreEmployee.SatisfactionScoreId;

            _bloggingContext.SaveChanges();

        }
    }
}
