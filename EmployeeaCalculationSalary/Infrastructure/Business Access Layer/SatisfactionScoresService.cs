using EmployeeaCalculationSalary.Infrastructure.Data_Access_Layer;
using EmployeeaCalculationSalary.Infrastructure.Models;
using System;
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
            => Math.Round(GetSatisfactionScoresByEmployeeId(employee.EmployeeId)
                                .Select(satisfaction => satisfaction.SatisfactionScore)
                                .Average(), 0, MidpointRounding.AwayFromZero);

        public IEnumerable<SatisfactionScores> GetSatisfactionScores() => _bloggingContext.SatisfactionScores;

        public IEnumerable<SatisfactionScores> GetSatisfactionScoresByEmployeeId(int EmployeeId)
        {
            var yearsWorkedEmployee = _bloggingContext.YearsWorkedEmployees
                .Where(yearsEmployee => yearsEmployee.EmployeeId == EmployeeId);

            return GetSatisfactionScores()
                .Where(satisfaction => yearsWorkedEmployee
                .Any(satisfactionId => satisfactionId.SatisfactionScoreId == satisfaction.SatisfactionScoreId));
        }

        public int GetMaxSatisfactionScore(Employees employees)
         => GetSatisfactionScoresByEmployeeId(employees.EmployeeId).Select(satisfaction => satisfaction.SatisfactionScore).Max();

        public Dictionary<int, string> GetSatisfactionsBonuses()
            => GetSatisfactionScores().ToDictionary(key => key.SatisfactionScore, value => value.Bonus);
    }
}
