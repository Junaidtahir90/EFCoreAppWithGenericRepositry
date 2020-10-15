using System;
using Common;
using EFCoreDemoApp.Repositries;
using Service;

namespace EFCoreDemoApp
{
    class Program
    {
       
        static void Main(string[] args)
        {
            var _context = new EmployeeContext("Persist Security Info = false; Integrated Security = true; Initial Catalog = devDatabase; server = HAMZAPC");
            //var service = new EmployeeService(_context);
            var genService = new EmployeeService();
            EmployeeRepositry employeeRepositry = new EmployeeRepositry(_context);
            var existingEmployee = new Employee();

            #region GetById
            var employee = genService.GetById(1);
            Console.WriteLine($"Welcome first emplyoee details are " + employee.Name + " Your Salary is : " + employee.Salary);
            #endregion

            #region Create Employee

            Employee newEmployee = new Employee();
            newEmployee.Name = "John";
            newEmployee.Salary = 45000;
            Employee employeeDTO = genService.Create(newEmployee);

            Console.WriteLine("New Employee is ");
            {
                Console.WriteLine($"Welcome " + employeeDTO.Name + " Your Salary is : " + employeeDTO.Salary);
            }
            #endregion

            #region Update Employee
            existingEmployee = genService.GetById(4);
            existingEmployee.Name = "Murphy";
            existingEmployee.Salary = 45000;
            Employee updatedEmployee = genService.Update(existingEmployee);
            Console.WriteLine("Updated Employee is ");
            {
                Console.WriteLine($"Welcome " + updatedEmployee.Name + " Your Salary is : " + updatedEmployee.Salary);
            }
            #endregion

            #region Delete Employee
            int id = 8;
            //string Name = "Mareena";
            var result = genService.Delete(id);
            {
                Console.WriteLine(result);
            }
            #endregion

            #region GetAll
            var employeesList = genService.Get();
            Console.WriteLine("Employee Details are below as");
            foreach (var emp in employeesList)
            {
                Console.WriteLine($"Welcome " + emp.Name + " Your Salary is : " + emp.Salary);
            }
            #endregion

            Console.WriteLine("Duplicate Records");
            var duplicateRows = employeeRepositry.DuplicateRecords();
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

        }
    }
}
