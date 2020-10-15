using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Collections;
using System.Collections.Generic;

namespace EFCoreDemoApp.Repositries
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(long id);
        T Insert(T obj);
        T Update(T obj);
        string Delete(long id);
        void Save();
    }
}