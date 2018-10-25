
using EmployeeaCalculationSalary.Infrastructure.View_Models;

namespace EmployeeaCalculationSalary.Infrastructure.Helpers
{
    public interface IEmployeeSalaryCalculation
    {
        double GetCalculatedEmployeeSalary(EmployeeCalculationViewModel employeeCalculationViewModel);
    }
}
