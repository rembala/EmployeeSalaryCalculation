using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeaCalculationSalary.Infrastructure.Models
{
    public class SatisfactionScores
    {
        [Key]
        public int SatisfactionScoreId { get; set; }
        public int SatisfactionScore { get; set; }
        public string Bonus { get; set; }

        public ICollection<Employees> satisfactionScores { get; set; }

        public ICollection<YearsWorkedEmployees> yearsWorkedEmployees { get; set; }

    }
}
