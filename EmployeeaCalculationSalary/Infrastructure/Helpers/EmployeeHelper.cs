
using EmployeeaCalculationSalary.Infrastructure.Business_Access_Layer;
using EmployeeaCalculationSalary.Infrastructure.View_Models;
using System.Collections.Generic;

namespace EmployeeaCalculationSalary.Infrastructure.Helpers
{
    public class EmployeeHelper : IEmployeeHelper
    {
        private readonly IEmployeesService _employeesService;
        private readonly IManagerService _managerService;
        private readonly IYearsWorkedEmployeesService _yearsWorkedEmployeesService;
        private readonly ISatisfactionScoresService _satisfactionScoresService;
        private readonly IEmployeeSalaryCalculation _employeeSalaryCalculation;

        public EmployeeHelper(
            IEmployeesService employeesService,
            IManagerService managerService,
            IYearsWorkedEmployeesService yearsWorkedEmployees,
            ISatisfactionScoresService satisfactionScoresService,
            IEmployeeSalaryCalculation employeeSalaryCalculation)
        {
            _employeesService = employeesService;
            _managerService = managerService;
            _yearsWorkedEmployeesService = yearsWorkedEmployees;
            _satisfactionScoresService = satisfactionScoresService;
            _employeeSalaryCalculation = employeeSalaryCalculation;
        }

        public IEnumerable<EmployeeListViewModel> CreateEmployeeListViewModel()
        {
            var employeeListViewModel = new List<EmployeeListViewModel>();

            var employees = _employeesService.GetEmployees();
            var managers = _managerService.GetManagers();
            var employeesWorkedYears = _yearsWorkedEmployeesService.GetYearsWorkedEmployees();

            foreach (var employee in employees)
            {
                var manager = _managerService.GetManagerByEmployeeId(employee);

                var satisfactionAverage = _satisfactionScoresService.GetSatisfactionAverageOfPastThreeYears(employee);

                var employeeYearsSatisfactionScores = _yearsWorkedEmployeesService.GetEmployeeYearsSatisfacions(employee.EmployeeId);
                
                var employeeLastYearSatisfaction = _employeesService.GetEmmployeeLastYearSatisfaction(employeeYearsSatisfactionScores);

                var salaryAfterComputation = _employeeSalaryCalculation.GetCalculatedEmployeeSalary(new EmployeeCalculationViewModel()
                {
                    CurrentSalary = employee.CurrentSalary,
                    MaxSatisfaction = employeeLastYearSatisfaction.SatisfactionScore,
                    SatisfactionAverage = satisfactionAverage
                });

                employeeListViewModel.Add(new EmployeeListViewModel()
                {
                    CurrentSalary = employee.CurrentSalary,
                    EmployeeManager = manager.ManagerName,
                    EmployeeName = employee.EmployeeName,
                    Position = employee.Position,
                    SatisfactionAverage = satisfactionAverage,
                    SalaryAfterCalculation = salaryAfterComputation,
                    YearsSatisfactionScores = employeeYearsSatisfactionScores,
                    EmployeeMaxYearViewModel = employeeLastYearSatisfaction
                });
            }

            return employeeListViewModel;
        }
    }
}