using EmployeeaCalculationSalary.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeaCalculationSalary.Infrastructure.Data_Access_Layer
{
    public class EmployeesSalaryCalculationContext : DbContext
    {
        public EmployeesSalaryCalculationContext(DbContextOptions<EmployeesSalaryCalculationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Test data

            modelBuilder.Entity<Employees>().HasData(
               new Employees()
               {
                   EmployeeId = 1,
                   CurrentSalary = 1200,
                   EmployeeName = "Artur",
                   ManagerId = 1,
                   SatisfactionScoreId = 6,
                   Position = "Technican"
               },
                new Employees()
                {
                    EmployeeId = 2,
                    CurrentSalary = 1200,
                    EmployeeName = "John",
                    ManagerId = 2,
                    SatisfactionScoreId = 1,
                    Position = "Sales representatives"
                }
               );

            modelBuilder.Entity<Managers>().HasData(
            new Managers()
            {
                ManagerId = 1,
                ManagerName = "Valdas"
            },
             new Managers()
             {
                 ManagerId = 2,
                 ManagerName = "Giedrius"
             }
            );

            modelBuilder.Entity<SatisfactionScores>().HasData(
             new SatisfactionScores()
             {
                 Bonus = "0%",
                 SatisfactionScoreId = 1,
                 SatisfactionScore = 0
             },
             new SatisfactionScores()
             {
                 Bonus = "0%",
                 SatisfactionScoreId = 2,
                 SatisfactionScore = 1
             },
              new SatisfactionScores()
              {
                  Bonus = "2%",
                  SatisfactionScoreId = 3,
                  SatisfactionScore = 2
              },
              new SatisfactionScores()
              {
                  Bonus = "7%",
                  SatisfactionScoreId = 4,
                  SatisfactionScore = 3
              },
              new SatisfactionScores()
              {
                  Bonus = "15%",
                  SatisfactionScoreId = 5,
                  SatisfactionScore = 4
              },
              new SatisfactionScores()
              {
                  Bonus = "20%",
                  SatisfactionScoreId = 6,
                  SatisfactionScore = 5
              }
             );

            modelBuilder.Entity<YearsWorkedEmployees>().HasData(
                  new YearsWorkedEmployees()
                  {
                      YearsWorkedId = 1,
                      EmployeeId = 1,
                      YearsWorked = "2016",
                      SatisfactionScoreId = 3
                  },
                  new YearsWorkedEmployees()
                  {
                      YearsWorkedId = 2,
                      EmployeeId = 1,
                      YearsWorked = "2017",
                      SatisfactionScoreId = 6
                  },
                   new YearsWorkedEmployees()
                   {
                       YearsWorkedId = 3,
                       EmployeeId = 1,
                       YearsWorked = "2015",
                       SatisfactionScoreId = 1
                   },
                   new YearsWorkedEmployees()
                   {
                       YearsWorkedId = 4,
                       EmployeeId = 2,
                       YearsWorked = "2015",
                       SatisfactionScoreId = 2
                   },
                   new YearsWorkedEmployees()
                   {
                       YearsWorkedId = 5,
                       EmployeeId = 2,
                       YearsWorked = "2016",
                       SatisfactionScoreId = 4
                   },
                   new YearsWorkedEmployees()
                   {
                       YearsWorkedId = 6,
                       EmployeeId = 2,
                       YearsWorked = "2017",
                       SatisfactionScoreId = 6
                   }
                  );

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<Managers> Managers { get; set; }
        public DbSet<SatisfactionScores> SatisfactionScores { get; set; }
        public DbSet<YearsWorkedEmployees> YearsWorkedEmployees { get; set; }
    }
}
