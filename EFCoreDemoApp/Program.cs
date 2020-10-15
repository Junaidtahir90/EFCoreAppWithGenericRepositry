using EFCoreDemoApp.Models;
using EFCoreDemoApp.Repositries;
using EFCoreDemoApp.Services;
using System;

namespace EFCoreDemoApp
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //var connectionString = "Persist Security Info=false; Integrated Security=true; Initial Catalog=devDatabase; server=HAMZAPC";
            var _context = new EmployeeContext("Persist Security Info = false; Integrated Security = true; Initial Catalog = devDatabase; server = HAMZAPC");
            //string connectionString = "Data Source=HAMZAPC;Initial Catalog=devDatabase;Integrated Security=True";
             
            var service = new EmployeeService(_context);
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
            //  foreach (var emp in employeesList)
            {
                Console.WriteLine($"Welcome " + employeeDTO.Name + " Your Salary is : " + employeeDTO.Salary);
            }
            #endregion

            #region Update Employee
            existingEmployee = genService.GetById(4);
            // Employee newEmployee = new Employee();
            existingEmployee.Name = "Murphy";
            existingEmployee.Salary = 45000;
            Employee updatedEmployee = genService.Update(existingEmployee);
            Console.WriteLine("Updated Employee is ");
            //  foreach (var emp in employeesList)
            {
                Console.WriteLine($"Welcome " + updatedEmployee.Name + " Your Salary is : " + updatedEmployee.Salary);
            }
            #endregion

            #region Delete Employee
            // existingEmployee = service.Get(8);
            int id = 8;
            //string Name = "Mareena";
            var result = genService.Delete(id);
            // Console.WriteLine("Deleted Record");
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
