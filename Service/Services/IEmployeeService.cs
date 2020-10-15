using Common;
using System.Collections.Generic;

namespace Service
{
    public interface IEmployeeService
    {
        List<Employee> Get();
        Employee Create(Employee obj);
        Employee GetById(long id);
        Employee Update(Employee obj);
        string Delete(long id);
    }
}