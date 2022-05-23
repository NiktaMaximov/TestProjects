using EFCoreTestApp.Dal;
using EFCoreTestApp.Models.Interfaces;
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
            System.Console.WriteLine($"Delete Product - {id}");
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public IEnumerable<Product> GetFilterProducts(string category = null, decimal? price = null)
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

            return data;
        }

        public Product GetProduct(long id)
        {
            return _context.Products.Find(id);
        }

        public void UpadteProduct(Product changeProduct)
        {
            _context.Products.Update(changeProduct);
            _context.SaveChanges();
        }
    }
}
