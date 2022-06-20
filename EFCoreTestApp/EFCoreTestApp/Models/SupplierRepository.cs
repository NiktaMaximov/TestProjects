using EFCoreTestApp.Dal;
using EFCoreTestApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreTestApp.Models
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
            _context.Remove(Get(id));
            _context.SaveChanges();
        }

        public Supplier Get(long id)
        {
            return _context.Suppliers.Find(id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            // Явная заргузка
            //IEnumerable<Supplier> data = _context.Suppliers.ToArray();

            //foreach (var item in data)
            //{
            //    _context.Entry(item).Collection(e => e.Products)
            //        .Query()
            //        .Where(p => p.Price > 5)
            //        .Load();
            //}
            //return data;

            // Исправление
            //_context.Products.Where(p => p.Supplier != null && p.Price > 5).Load();
            //return _context.Suppliers;

            return _context.Suppliers.Include(p => p.Products);
        }

        public void Update(Supplier changeDataObject)
        {
            _context.Update(changeDataObject);
            _context.SaveChanges();
        }
    }
}
