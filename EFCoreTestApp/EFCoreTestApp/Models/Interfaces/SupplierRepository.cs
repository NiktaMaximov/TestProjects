using EFCoreTestApp.Dal;
using System.Collections.Generic;

namespace EFCoreTestApp.Models.Interfaces
{
    public class SupplierRepository : ISupplierRepository
    {
        private EFDatabaseContext _context;

        public SupplierRepository(EFDatabaseContext context)
        {
            _context = context;
        }

        public void Create(Supplier newDataObject)
        {
            _context.Suppliers.Add(newDataObject);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            _context.Remove(this.Get(id));
            _context.SaveChanges();
        }

        public Supplier Get(long id)
        {
            return _context.Suppliers.Find(id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _context.Suppliers;
        }

        public void Update(Supplier changeDataObject)
        {
            _context.Update(changeDataObject);
            _context.SaveChanges();
        }
    }
}
