using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utilities;

namespace EFCoreDemoApp
{
    public class Startup
    {
       private   IConfiguration _configuration { get; }

        //public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        //{
        //   // _configuration = configuration;
        //    _hostingEnvironment = hostingEnvironment;
        //    // Set up configuration sources.
        //    //var builder = new ConfigurationBuilder()
        //    //.SetBasePath(_hostingEnvironment.ContentRootPath)
        //    //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //    //.AddJsonFile($"appsettings.{_hostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
        //}
        //IConfiguration Configuration { get; }

        //public Startup()
        //{
        //    var builder = new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json");

        //    Configuration = builder.Build();
        //}
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public Startup(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRepository();
            services.AddDbContext<EmployeeContext>(opt => opt.UseSqlServer("Persist Security Info = false; Integrated Security = true; Initial Catalog = devDatabase; server = HAMZAPC"));
            //services.AddControllers();
        }


    }
}
