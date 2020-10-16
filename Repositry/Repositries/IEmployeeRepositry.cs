using System.Collections.Generic;
using Utilities;
using Utilities.DTO;

namespace Repositry.Repositries
{
    public interface IEmployeeRepositry : IGenericRepository<Employee>
    {
        List<ResultDTO> DuplicateRecords();
    }
}