using EFCoreDemoApp.Models;
using EFCoreDemoApp.Repositries;
using System.Collections.Generic;
using System.Linq;

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

        public EmployeeService(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
           
        }
     
        public List<Employee> Get()
        {
            return _genericRepository.GetAll().ToList();
        }
        public Employee Create(Employee employee)
        {
            var newEmplyee = _genericRepository.Create(employee);
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
            updEmplyee = _genericRepository.Update(employee);
            return updEmplyee;
        }

        public string Delete(long id)
        {
            return _genericRepository.Delete(id);
        }
    }
}
