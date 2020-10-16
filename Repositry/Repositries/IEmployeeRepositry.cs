using Common;
using System.Collections.Generic;

namespace Repositry.Repositries
{
    public interface IEmployeeRepositry : IGenericRepository<Employee>
    {
        List<ResultDTO> DuplicateRecords();
    }
}