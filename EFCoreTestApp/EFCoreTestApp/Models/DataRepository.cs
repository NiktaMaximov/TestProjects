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
            System.Console.WriteLine($"Create Product - {JsonConvert.SerializeObject(newProduct)}");
        }

        public void DeleteProduct(long id)
        {
            System.Console.WriteLine($"Delete Product - {id}");
        }

        public IEnumerable<Product> GetAllProducts()
        {
            System.Console.WriteLine("GetAllProducts");
            return _context.Products;
        }

        public Product GetProduct(long id)
        {
            System.Console.WriteLine("GetProduct");
            return new Product();
        }

        public void UpadteProduct(Product changeProduct)
        {
            System.Console.WriteLine($"Create Product - {JsonConvert.SerializeObject(changeProduct)}");
        }
    }
}
