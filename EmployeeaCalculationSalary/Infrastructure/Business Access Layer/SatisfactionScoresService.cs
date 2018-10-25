using EmployeeaCalculationSalary.Infrastructure.Data_Access_Layer;
using EmployeeaCalculationSalary.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeaCalculationSalary.Infrastructure.Business_Access_Layer
{
    public class SatisfactionScoresService : ISatisfactionScoresService
    {
        private readonly EmployeesSalaryCalculationContext _bloggingContext;

        public SatisfactionScoresService(
            EmployeesSalaryCalculationContext bloggingContext)
        {
            _bloggingContext = bloggingContext;
        }

        public double GetSatisfactionAverageOfPastThreeYears(Employees employee)
            => GetSatisfactionScoresByEmployee(employee)
                                .Select(satisfaction => satisfaction.SatisfactionScore)
                                .Average();

        public IEnumerable<SatisfactionScores> GetSatisfactionScores() => _bloggingContext.SatisfactionScores;

        public IEnumerable<SatisfactionScores> GetSatisfactionScoresByEmployee(Employees employees)
        {
            var satisfactionIds = _bloggingContext.YearsWorkedEmployees
                .Where(yearsEmployee => yearsEmployee.EmployeeId == employees.EmployeeId);

            return GetSatisfactionScores()
                .Where(satisfaction => satisfactionIds
                .Any(satisfactionId => satisfactionId.SatisfactionScoreId == satisfaction.SatisfactionScoreId));
        }

        public int GetMaxSatisfactionScore(Employees employees)
         => GetSatisfactionScoresByEmployee(employees).Select(satisfaction => satisfaction.SatisfactionScore).Max();

        public Dictionary<int, string> GetSatisfactionsBonuses()
            => GetSatisfactionScores().ToDictionary(key => key.SatisfactionScore, value => value.Bonus);
    }
}
