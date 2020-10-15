using System.Collections.Generic;

namespace EFCoreDemoApp.Repositries
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(long id);
        T Create(T obj);
        T Update(T obj);
        string Delete(long id);
        void Save();
    }
}