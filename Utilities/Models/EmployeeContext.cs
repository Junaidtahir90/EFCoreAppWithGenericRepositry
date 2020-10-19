using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Utilities
{
    public class EmployeeContext : DbContext
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public EmployeeContext(string configuration)
        {
            //s_configuration = configuration;
            //connectionString = _configuration.GetConnectionString("DBConnection");
            _connectionString = configuration;
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            //base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
