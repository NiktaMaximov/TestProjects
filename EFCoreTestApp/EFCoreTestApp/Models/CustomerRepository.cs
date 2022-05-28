using EFCoreTestApp.Dal;
using EFCoreTestApp.Models.Interfaces;
using System.Collections.Generic;

namespace EFCoreTestApp.Models
{
    public class CustomerRepository:ICustomerRepository
    {
        private EFCustomerContext _context;
        public CustomerRepository(EFCustomerContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return _context.Customers;
        }
    }
}
