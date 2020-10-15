using EFCoreDemoApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemoApp
{
    public class EmployeeContext :  DbContext
    {
        private readonly string _connectionString;
       
        public EmployeeContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            //base.OnConfiguring(optionsBuilder);
        }
    }
}
