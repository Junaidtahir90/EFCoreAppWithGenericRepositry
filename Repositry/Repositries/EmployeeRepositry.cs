﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Utilities;
using Utilities.DTO;

namespace Repositry.Repositries
{
    public class EmployeeRepositry : GenericRepository<Employee>, IEmployeeRepositry //IEmployeeRepositry
    {
        //private readonly string _context = "Persist Security Info = false; Integrated Security = true; Initial Catalog = devDatabase; server = HAMZAPC";
        //private  EmployeeContext _context;
        private readonly IConfiguration _configuration;
        //public TestModel(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public EmployeeRepositry(EmployeeContext context, IConfiguration configuration) : base(context)
        {
            _context = context;
            _configuration = configuration;
        }

        //public SqlConnection GetOpenConnection()
        //{
        //    string cs = config["ConnectionStrings:DBConnection"];
        //    SqlConnection connection = new SqlConnection(cs);
        //    connection.Open();
        //    return connection;
        //}

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
            string cs = _configuration["ConnectionStrings:DBConnection"];
            using (var connection = new System.Data.SqlClient.SqlConnection(cs))
            {
                connection.Open();
                results = connection.Query<ResultDTO>("_SPDuplicateRecords",
                                    commandType: CommandType.StoredProcedure).ToList();
            }
            return results;
        }
    }
}
