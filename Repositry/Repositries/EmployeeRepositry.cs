using Common;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Repositry.Repositries
{
    public class EmployeeRepositry : GenericRepository<Employee>, IEmployeeRepositry //IEmployeeRepositry
    {
        private readonly string _context = "Persist Security Info = false; Integrated Security = true; Initial Catalog = devDatabase; server = HAMZAPC";

        public EmployeeRepositry(EmployeeContext context) : base(context)
        {
        }
       
        /// <summary>
        /// Using Dapper with SP
        /// Giving connection as connection String
        /// Exposing connection.query with dynamic or specific return type with SP Name
        /// Convert it to required data type as .toList
        /// </summary>
        /// <param>Id with respect to dynamic(model type)</param>
        /// <returns>Retruns dynamic (model type) entity against the Id </returns>
        /// 
        public List<ResultDTO> DuplicateRecords()
        {
            List<ResultDTO> results = new List<ResultDTO>();
            using (var connection = new System.Data.SqlClient.SqlConnection(_context))
            {
                connection.Open();
                results = connection.Query<ResultDTO>("_SPDuplicateRecords",
                                    commandType: CommandType.StoredProcedure).ToList();
            }
            return results;
        }
    }
}
