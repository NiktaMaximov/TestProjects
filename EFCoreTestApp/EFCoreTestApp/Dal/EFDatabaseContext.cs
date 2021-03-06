using EFCoreTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTestApp.Dal
{
    public class EFDatabaseContext : DbContext
    {
        public EFDatabaseContext(DbContextOptions<EFDatabaseContext> opts) : base(opts)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
