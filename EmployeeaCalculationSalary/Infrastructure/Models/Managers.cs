
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeaCalculationSalary.Infrastructure.Models
{
    public class Managers
    {
        [Key]
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }

    }
}
