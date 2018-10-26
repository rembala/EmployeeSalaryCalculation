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

        public EmployeesService(EmployeesSalaryCalculationContext bloggingContext, ISatisfactionScoresService satisfactionScoresService)
        {
            _bloggingContext = bloggingContext;
            _satisfactionScoresService = satisfactionScoresService;
        }

        public IEnumerable<Employees> GetEmployees() => _bloggingContext.Employees;

        public EmployeeMaxYearViewModel GetEmmployeeMaxYearSatisfaction(IEnumerable<YearsSatisfactionsViewModel> yearsSatisfactions)
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

        public void UpdateEmployeeSatisfactionScore(int employeeId, int satisfactionScore)
        {
            var employeeSatisfactionScores = _satisfactionScoresService.GetSatisfactionScores()
                .FirstOrDefault(satisfaction => satisfaction.SatisfactionScore == satisfactionScore);

            var employee = _bloggingContext.Employees.FirstOrDefault(empl => empl.EmployeeId == employeeId);

            employee.SatisfactionScoreId = employeeSatisfactionScores.SatisfactionScoreId;
            _bloggingContext.SaveChanges();

        }
    }
}
