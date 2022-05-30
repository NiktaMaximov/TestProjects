using System.Collections.Generic;
using System.Linq;

namespace EFCoreTestApp.Models.Interfaces
{
    public interface IDataRepository
    {
        Product GetProduct(long id);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetFilterProducts(string category=null, decimal? price = null, bool includeRelated = true);
        void CreateProduct(Product newProduct);
        void UpadteProduct(Product changeProduct, Product originalProdut = null);
        void DeleteProduct(long id);
    }
}
