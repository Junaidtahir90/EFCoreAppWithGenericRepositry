using EFCoreDemoApp.Models;
using EFCoreDemoApp.Repositries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemoApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _employeeContext;
        private GenericRepository<Employee> _genericRepository;

        public EmployeeService()
        {
            _genericRepository = new GenericRepository<Employee>();
        }

        //public EmployeeService(IGenericRepository<Employee> repo)
        //{
        //    _genericRepository = repo;
        //}
        public EmployeeService(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
           
        }
        //public Employee Get(long id)
        //{
        //    return _employeeContext.Employees.FirstOrDefault(emp => emp.Id == (id));
        //}
        //public List<Employee> GetAll()
        //{
        //    return _employeeContext.Employees.ToList();
        //}
        public List<Employee> Get()
        {
            return _genericRepository.GetAll().ToList();
        }
        public Employee Create(Employee employee)
        {
            var newEmplyee = _genericRepository.Insert(employee);
            return newEmplyee;
        }
        public Employee GetById(long id)
        {
            Employee employee = _genericRepository.GetById(id);
            return employee;
        }
        public Employee Update(Employee employee)
        {
            Employee updEmplyee = new Employee();
            //var existingEmployee = _employeeContext.Employees.FirstOrDefault(emp => emp.Id == employee.Id);
            //if (existingEmployee != null)
            //{
            //    _employeeContext.Update(employee);
            //    _employeeContext.SaveChanges();
            //    return employee;
            //}
            //else
            //{
            //    return updEmplyee;
            //}
            updEmplyee= _genericRepository.Update(employee);
            return updEmplyee;
        }

        public string Delete(long id)
        {
            return _genericRepository.Delete(id);
        }
     

      
    }
}
