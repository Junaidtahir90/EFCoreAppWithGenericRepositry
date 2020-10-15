using EFCoreDemoApp.Models;
using System.Collections.Generic;

namespace EFCoreDemoApp.Repositries
{
    public interface IEmployeeRepositry : IGenericRepository<Employee>
    {
        //Employee Create(Employee employee);
        //Employee Update(Employee employee);
        //string Delete(long employeeId,string name);
        //List<ResultDTO> DuplicateRecords();

    }
}