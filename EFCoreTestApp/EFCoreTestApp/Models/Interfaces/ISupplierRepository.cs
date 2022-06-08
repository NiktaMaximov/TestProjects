using System.Collections.Generic;

namespace EFCoreTestApp.Models.Interfaces
{
    public interface ISupplierRepository
    {
        Supplier Get(long id);
        IEnumerable<Supplier> GetAll();
        void Create(Supplier newDataObject);
        void Update(Supplier changeDataObject);
        void Delete(long id);
    }
}
