using EmployeeaCalculationSalary.Infrastructure.Business_Access_Layer;
using EmployeeaCalculationSalary.Infrastructure.View_Models;
using System;

/// <summary>
/// Calculation was made using formula: P% * X = Y https://www.calculatorsoup.com/calculators/math/percentage.php
/// </summary>
/// 

namespace EmployeeaCalculationSalary.Infrastructure.Helpers
{
    public class EmployeeSalaryCalculation : IEmployeeSalaryCalculation
    {
        private readonly ISatisfactionScoresService _satisfactionScoresService;

        public EmployeeSalaryCalculation(ISatisfactionScoresService satisfactionScoresService)
        {
            _satisfactionScoresService = satisfactionScoresService;
        }

        public double GetCalculatedEmployeeSalary(EmployeeCalculationViewModel employeeCalculationViewModel)
        {
            var satisfactions = _satisfactionScoresService.GetSatisfactionsBonuses();

            var computedSatisfaction = Math.Round(
                Decimal.Parse($"{employeeCalculationViewModel.SatisfactionAverage}.{employeeCalculationViewModel.LastYearSatisfactionScore}"),
                0,
                MidpointRounding.AwayFromZero);

            var p = int.Parse(satisfactions[int.Parse(computedSatisfaction.ToString())].Replace('%', ' ')) / 100.0;

            var y = employeeCalculationViewModel.CurrentSalary * p;

            return y + employeeCalculationViewModel.CurrentSalary;
        }
    }
}