﻿using EFCoreDemoApp.Models;
using System.Collections.Generic;

namespace EFCoreDemoApp.Repositries
{
    public interface IEmployeeRepositry : IGenericRepository<Employee>
    {
        List<ResultDTO> DuplicateRecords();
    }
}