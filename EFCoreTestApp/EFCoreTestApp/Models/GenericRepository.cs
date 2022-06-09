using EFCoreTestApp.Dal;
using EFCoreTestApp.Models.Interfaces;
using System.Collections.Generic;

namespace EFCoreTestApp.Models
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected EFDatabaseContext _context;

        public GenericRepository(EFDatabaseContext context)
        {
            _context = context;
        }

        public virtual void Create(T newObject)
        {
            _context.Add<T>(newObject);
            _context.SaveChanges();
        }

        public virtual void Delete(long id)
        {
            _context.Remove<T>(this.Get(id));
            _context.SaveChanges();
        }

        public virtual T Get(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual void Update(T changeObject)
        {
            _context.Update<T>(changeObject);
            _context.SaveChanges();
        }
    }
}
