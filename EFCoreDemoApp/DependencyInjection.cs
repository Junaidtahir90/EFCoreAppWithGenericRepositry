using AspNetCore.ServiceRegistration.Dynamic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositry.Repositries;
using Utilities;

namespace EFCoreDemoApp
{
    public static class DependencyInjection
    {
        public static IConfiguration Configuration { get; }
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
           // services.AddDbContextPool<EmployeeContext>(context => context.UseSqlServer(configuration.GetConnectionString("DBConnection")));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
          
            #region Register Services
            services.AddServicesOfType<IScopedService>();
            services.AddServicesWithAttributeOfType<ScopedServiceAttribute>();
            #endregion

            // services.AddDbContextPool<EmployeeContext>(context => context.UseSqlServer(config.GetConnectionString("DBConnection")));
            //services.AddDbContext<EmployeeContext>(opt => opt.UseSqlServer(config.GetConnectionString("DBConnection")));
            services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            //services.AddDbContext<EmployeeContext>(opt => opt.UseSqlServer(config.GetConnectionString("DBConnection")));

            return services;
        }
    }
}
