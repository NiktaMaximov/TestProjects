using EFCoreTestApp.Dal;
using EFCoreTestApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreTestApp.Models
{
    public class DataRepository:IDataRepository
    {
        private EFDatabaseContext _context;

        public DataRepository(EFDatabaseContext context)
        {
            _context = context;
        }

        public void CreateProduct(Product newProduct)
        {
            newProduct.Id = 0;
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        public void DeleteProduct(long id)
        {
            Product p = _context.Products.Find(id);
            _context.Products.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.Include(p => p.Supplier);
            //return _context.Products;
        }

        public IEnumerable<Product> GetFilterProducts(string category = null, decimal? price = null, bool includeRelated = true)
        {
            IQueryable<Product> data = _context.Products;

            if(category != null)
            {
                data = data.Where(p => p.Category == category);
            }
            if(price != null)
            {
                data = data.Where(p => p.Price >= price);
            }
            if(includeRelated)
            {
                data = data.Include(p => p.Supplier);
            }

            return data;
        }

        public Product GetProduct(long id)
        {
            //return _context.Products.Find(id);
            return _context.Products.Include(p => p.Supplier).First(p => p.Id == id);
        }

        public void UpadteProduct(Product changeProduct, Product originalProduct = null)
        {
            if(originalProduct == null)
                originalProduct = _context.Products.Find(changeProduct.Id);
            else
                _context.Products.Attach(originalProduct);

            originalProduct.Name = changeProduct.Name;
            originalProduct.Category = changeProduct.Category;
            originalProduct.Price = changeProduct.Price;

            EntityEntry entity = _context.Entry(originalProduct);
            System.Console.WriteLine($"Entry state {entity.State}");

            foreach (var item in new string[] { "Name", "Category", "Price" })
            {
                System.Console.WriteLine($"{item} OLD: {entity.OriginalValues[item]} NEW: {entity.CurrentValues[item]}");
            }

            _context.SaveChanges();
        }
    }
}
