using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeaCalculationSalary.Infrastructure.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Position { get; set; }
        public int CurrentSalary { get; set; }
        public int ManagerId { get; set; }
        public int SatisfactionScoreId { get; set; }
    }
}
