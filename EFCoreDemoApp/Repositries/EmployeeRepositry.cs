using Dapper;
using EFCoreDemoApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EFCoreDemoApp.Repositries
{
    public class EmployeeRepositry : GenericRepository<Employee>, IEmployeeRepositry //IEmployeeRepositry
    {
        //private IGenericRepository<Employee> repository = null;
        private readonly EmployeeContext _employeeContext;
        private GenericRepository<Employee> _genericRepository;
        //public BooksController(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}
        public EmployeeRepositry(EmployeeContext context) : base(context)
        {
        }
        private readonly string _context = "Persist Security Info = false; Integrated Security = true; Initial Catalog = devDatabase; server = HAMZAPC";

        //public EmployeeRepositry(EmployeeContext employeeContext)
        //{
        //    _employeeContext = employeeContext;
        //}

        //public Employee Create(Employee employee)
        //{
        //    employee.Id = 100;
        //    var newEmplyee= _genericRepository.Insert(employee);
        //    //Employee newEmplyee = new Employee();
        //    //newEmplyee.Name = employee.Name;
        //    //newEmplyee.Salary = employee.Salary;
        //    //_employeeContext.Add(newEmplyee);
        //    //_employeeContext.SaveChanges();
        //    return newEmplyee;
        //}
        //public Employee Update(Employee employee)
        //{
        //    Employee updEmplyee = new Employee();
        //    var existingEmployee = _employeeContext.Employees.FirstOrDefault(emp => emp.Id == employee.Id);
        //    if(existingEmployee!= null)
        //    {
        //       _employeeContext.Update(employee);
        //       _employeeContext.SaveChanges();
        //        return employee;
        //    }
        //    else
        //    {
        //        return updEmplyee;
        //    }
        //}
        //public string Delete(long id,string name)
        //{
        //    var existingEmployee = new Employee();
        //    if (name != null){
        //         existingEmployee = _employeeContext.Employees.FirstOrDefault(emp => emp.Name == name);
        //    }
        //    else
        //    {
        //        existingEmployee = _employeeContext.Employees.FirstOrDefault(emp => emp.Id == id);
        //    }
           
        //    if (existingEmployee != null)
        //    {
        //        _employeeContext.Remove(existingEmployee);
        //        _employeeContext.SaveChanges();
        //        return "Record Deleted";
        //    }
        //    else
        //    {
        //        return "Record not Deleted";
        //    }
        //}

        public List<ResultDTO> DuplicateRecords()
        {
            List<ResultDTO> results = new List<ResultDTO>();
            using (var connection = new SqlConnection(_context))
            {
                 connection.Open();
                // Using Dapper with SP
                // giving connection as connection String
                // Exposing connectio.query with dynamic or specific return type with SP Name
                // Convert it to required data type as .toList
                results = connection.Query<ResultDTO>("_SPDuplicateRecords",
                                    commandType: CommandType.StoredProcedure).ToList();
            }
            return results;

        }
    }

}
