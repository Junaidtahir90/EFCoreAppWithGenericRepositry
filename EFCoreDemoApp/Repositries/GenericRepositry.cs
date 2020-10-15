using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreDemoApp.Repositries
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region variables
        public EmployeeContext _context = new EmployeeContext("Persist Security Info = false; Integrated Security = true; Initial Catalog = devDatabase; server = HAMZAPC");
        private DbSet<T> entity = null;
        #endregion

        /// <summary>
        /// Constructor of Generic Repositry 
        /// Sets the entity type dynamically w.r.t model type
        /// </summary>
       
        public GenericRepository()
        {
            entity = _context.Set<T>();
        }


        /// <summary>
        /// Constructor of Generic Repositry with param
        /// Inject the EmployeeContext in GenericRepository with param
        /// Sets the entity type dynamically w.r.t model type
        /// </summary>
        public GenericRepository(EmployeeContext _context)
        {
            this._context = _context;
            entity = _context.Set<T>();
        }

        /// <summary>
        /// Returns List of Dynamic <T>  as per ( model type) 
        /// </summary>
        /// <returns>Return List of Dynamic <T>  as per (model type) </returns>
        public IEnumerable<T> GetAll()
        {
            return entity.ToList();
        }

        /// <summary>
        /// Returns List of Dynamic <T> ( model type) 
        /// </summary>
        /// <param>Id with respect to dynamic(model type)</param>
        /// <returns>Retruns dynamic (model type) entity against the Id </returns>
        public T GetById(long id)
        {
            return entity.Find(id);
        }

        /// <summary>
        /// Create Record of Dynamic <T> ( model type) 
        /// </summary>
        /// <param>Dynamic <T> (entity) which are needs to created</param>
        /// <returns>Dynamic (Model Type) respect to dynamic(model type) </returns>
        public T Insert(T obj)
        {
            entity.Add(obj);
            Save();
            return obj;
        }

        /// <summary>
        /// Update Record of Dynamic <T> ( model type) 
        /// </summary>
        /// <param>Dynamic <T> (entity) which are needs to updateted</param>
        /// <returns>Return Dynamic (Model Type) respect to dynamic(model type) </returns>
        public T Update(T obj)
        {
            entity.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            Save();
            return obj;
        }

        /// <summary>
        ///Remove of Dynamic <T> ( model type) 
        /// </summary>
        /// <param>Id with respect to dynamic(model type) to be removed</param>
        /// <returns>Retruns specific String in case of sucess/failure of Deletion </returns>
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

        /// <summary>
        ///To Save Changes w.r.t context type
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
