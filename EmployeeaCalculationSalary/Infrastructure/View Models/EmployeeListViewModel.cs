
using System.Collections.Generic;

namespace EmployeeaCalculationSalary.Infrastructure.View_Models
{
    public class EmployeeListViewModel
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeManager { get; set; }

        public string Position { get; set; }

        public double SatisfactionAverage { get; set; }
        
        public int CurrentSalary { get; set; }

        public double SalaryAfterCalculation { get; set; }

        public IEnumerable<YearsSatisfactionsViewModel> YearsSatisfactionScores { get; set; }
    }
}
