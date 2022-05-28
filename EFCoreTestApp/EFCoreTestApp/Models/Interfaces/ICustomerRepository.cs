using System.Collections;
using System.Collections.Generic;

namespace EFCoreTestApp.Models.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomer();
    }
}
