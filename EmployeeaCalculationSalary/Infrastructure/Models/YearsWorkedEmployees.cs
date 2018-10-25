using System.ComponentModel.DataAnnotations;

namespace EmployeeaCalculationSalary.Infrastructure.Models
{
    public class YearsWorkedEmployees
    {
        [Key]
        public int YearsWorkedId { get; set; }
        public int EmployeeId { get; set; }
        public string YearsWorked { get; set; }
        public int SatisfactionScoreId { get; set; }

        public Employees Managers { get; set; }
        public SatisfactionScores SatisfactionScores { get; set; }
    }
}
