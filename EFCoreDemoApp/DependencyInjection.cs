using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositry.Repositries;
using Utilities;

namespace EFCoreDemoApp
{
    public static class DependencyInjection
    {
        private static string _connString = "Persist Security Info = false; Integrated Security = true; Initial Catalog = devDatabase; server = HAMZAPC";
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
           // services.AddTransient<IGenericRepository<T>, GenericRepository<T>>();
           // services.AddTransient<IEmployeeRepositry, EmployeeRepositry>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            // services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<EmployeeContext>(opt => opt
                .UseSqlServer(_connString));
            return services;
        }
    }
}
