using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Repositry.Repositries;
using Service;
using Utilities;

using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreDemoApp
{
     class Program
    {
        private static IConfiguration _configuration;
        //public IConfiguration _configuration { get; }
        // private readonly IConfiguration _configuration;

        //static IConfiguration _configuration;
        static void Main(string[] args)
        {
            //// private readonly string context = "Persist Security Info = false; Integrated Security = true; Initial Catalog = devDatabase; server = HAMZAPC";
            //var host = CreateHostBuilder(args).Build();
            // host.Run();
            // add the framework services
            //var services = new ServiceCollection()
            //    .AddLogging();

            //// add StructureMap
            //var container = new Container();
            //container.Configure(config =>
            //{
            //    // Register stuff in container, using the StructureMap APIs...
            //    config.Scan(_ =>
            //    {
            //        _.AssemblyContainingType(typeof(Program));
            //        _.WithDefaultConventions();
            //    });
            //    // Populate the container using the service collection
            //    config.Populate(services);
            //});

            //var serviceProvider = container.GetInstance<IServiceProvider>();

            // rest of method as before

            var _context = new EmployeeContext("Persist Security Info = false; Integrated Security = true; Initial Catalog = devDatabase; server = HAMZAPC");
            Startup startup = new Startup(_configuration);
            // //var service = new EmployeeService(_context);
            // var genService = new EmployeeService();
            // EmployeeRepositry employeeRepositry = new EmployeeRepositry(_context);
            // var existingEmployee = new Employee();
            //var _context = new EmployeeContext("Persist Security Info = false; Integrated Security = true; Initial Catalog = devDatabase; server = HAMZAPC");
            //var service = new EmployeeService(_context);
            var genService = new EmployeeService();
           // EmployeeRepositry employeeRepositry = new EmployeeRepositry(_context);
            EmployeeRepositry employeeRepositry1 = new EmployeeRepositry(_context, _configuration);
            var existingEmployee = new Employee();
            //#region GetById
            //var employee = genService.GetById(1);
            //Console.WriteLine($"Welcome first emplyoee details are " + employee.Name + " Your Salary is : " + employee.Salary);
            //#endregion

            //#region Create Employee

            //Employee newEmployee = new Employee();
            //newEmployee.Name = "John";
            //newEmployee.Salary = 45000;
            //Employee employeeDTO = genService.Create(newEmployee);

            //Console.WriteLine("New Employee is ");
            //{
            //    Console.WriteLine($"Welcome " + employeeDTO.Name + " Your Salary is : " + employeeDTO.Salary);
            //}
            //#endregion

            //#region Update Employee
            //existingEmployee = genService.GetById(4);
            //existingEmployee.Name = "Murphy";
            //existingEmployee.Salary = 45000;
            //Employee updatedEmployee = genService.Update(existingEmployee);
            //Console.WriteLine("Updated Employee is ");
            //{
            //    Console.WriteLine($"Welcome " + updatedEmployee.Name + " Your Salary is : " + updatedEmployee.Salary);
            //}
            //#endregion

            //#region Delete Employee
            //int id = 8;
            ////string Name = "Mareena";
            //var result = genService.Delete(id);
            //{
            //    Console.WriteLine(result);
            //}
            //#endregion

            //#region GetAll
            //var employeesList = genService.Get();
            //Console.WriteLine("Employee Details are below as");
            //foreach (var emp in employeesList)
            //{
            //    Console.WriteLine($"Welcome " + emp.Name + " Your Salary is : " + emp.Salary);
            //}
            //#endregion

          

            #region Dapper with SP
            Console.WriteLine("Duplicate Records");
            var duplicateRows = employeeRepositry1.DuplicateRecords();
            if (duplicateRows.Count > 0)
            {
                foreach (var dr in duplicateRows)
                {
                    Console.WriteLine($"Welcome " + dr.Name + " Your Salary is : " + dr.Salary + " \tCount : " + dr.count);
                }
            }
            else
            {
                Console.WriteLine("No Duplicate Records Found");
            }
            #endregion

            #region Enums
            Console.WriteLine("Read values of the Color enum");
            //foreach (string  i in Enums.Days)
            //    Console.WriteLine(i);
            //foreach (int i in Enums.GetValues(typeof()))
            //    Console.WriteLine(i);
            Console.WriteLine(Enums.Days.Friday); //output: Friday 
            int day = (int)Enums.Days.Friday; // enum to int conversion
            Console.WriteLine(day); //output: 5 

            var wd = (Enums.Days)5; // int to enum conversion
            Console.WriteLine(wd);//output: Friday 
            #endregion

        }
     
    }
}
