using EFCoreTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTestApp.Dal
{
    public class EFCustomerContext:DbContext
    {
        public EFCustomerContext(DbContextOptions<EFCustomerContext> opts):base(opts)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
