using System.Collections.Generic;

namespace EFCoreTestApp.Models.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(long id);
        IEnumerable<T> GetAll();
        void Create(T newObject);
        void Update(T changeObject);
        void Delete(long id);
    }
}
