using EmployeeaCalculationSalary.Infrastructure.Business_Access_Layer;
using EmployeeaCalculationSalary.Infrastructure.Helpers;
using EmployeeaCalculationSalary.Infrastructure.View_Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace EmployeeCalculationSalary
{
    [TestClass]
    public class EmployeeCalculationSalaryTest
    {
        [TestMethod]
        public void Should_Increase_Salary_by_15_percent()
        {
            var satisfactionScoreMock = new Mock<ISatisfactionScoresService>();
            satisfactionScoreMock.Setup(satisf => satisf.GetSatisfactionsBonuses())
                .Returns(new Dictionary<int, string>()
                {
                    { 0, "0%" },
                    { 1, "0%" },
                    { 2, "2%" },
                    { 3, "7%" },
                    { 4, "15%" },
                    { 5, "20%" }
                });

            var satisfactionCalculation = new EmployeeSalaryCalculation(satisfactionScoreMock.Object);
            var salaryWithBonus = satisfactionCalculation.GetCalculatedEmployeeSalary(new EmployeeCalculationViewModel()
            {
                CurrentSalary = 1200,
                LastYearSatisfactionScore = 5,
                SatisfactionAverage = 3
            });

            Assert.AreEqual(salaryWithBonus, 1380);
        }
    }
}
