﻿using EmployeeaCalculationSalary.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeaCalculationSalary.Infrastructure.Data_Access_Layer
{
    public class EmployeesSalaryCalculationContext : DbContext
    {
        public EmployeesSalaryCalculationContext(DbContextOptions<EmployeesSalaryCalculationContext> options)
            : base(options)
        { }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<Managers> Managers { get; set; }
        public DbSet<SatisfactionScores> SatisfactionScores { get; set; }
        public DbSet<YearsWorkedEmployees> YearsWorkedEmployees { get; set; }
    }
}