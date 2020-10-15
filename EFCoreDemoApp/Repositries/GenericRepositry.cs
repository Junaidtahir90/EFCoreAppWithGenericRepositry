using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreDemoApp.Repositries
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public EmployeeContext _context = new EmployeeContext("Persist Security Info = false; Integrated Security = true; Initial Catalog = devDatabase; server = HAMZAPC");
        private DbSet<T> entity = null;

        public GenericRepository()
        {
            entity = _context.Set<T>();
        }

        public GenericRepository(EmployeeContext _context)
        {
            this._context = _context;
            entity = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entity.ToList();
        }

        public T GetById(long id)
        {
            return entity.Find(id);
        }

        public T Insert(T obj)
        {
            entity.Add(obj);
            Save();
            return obj;
        }

        public T Update(T obj)
        {
            entity.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            Save();
            return obj;
        }

        public string Delete(long id)
        {

            T existing = entity.Find(id);
            if (existing != null)
            {
                entity.Remove(existing);
                Save();
                return "Record Deleted";
            }
            else
            {
                return "Record Not Found/Deleted";
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
