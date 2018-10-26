
using EmployeeaCalculationSalary.Infrastructure.Models;
using System.Collections.Generic;

namespace EmployeeaCalculationSalary.Infrastructure.Business_Access_Layer
{
    public interface ISatisfactionScoresService
    {
        IEnumerable<SatisfactionScores> GetSatisfactionScores();

        IEnumerable<SatisfactionScores> GetSatisfactionScoresByEmployeeId(int employeeId);

        double GetSatisfactionAverageOfPastThreeYears(Employees employee);

        int GetMaxSatisfactionScore(Employees employees);

        Dictionary<int, string> GetSatisfactionsBonuses();
    }
}
