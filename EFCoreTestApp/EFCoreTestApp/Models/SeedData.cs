using EFCoreTestApp.Dal;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCoreTestApp.Models
{
    public static class SeedData
    {
        public static void Seed(DbContext dbContext)
        {
            if (dbContext.Database.GetPendingMigrations().Count() == 0)
            {
                if (dbContext is EFDatabaseContext prodCtx && prodCtx.Products.Count() == 0)
                {
                    prodCtx.Products.AddRange(Products);
                }
                else if (dbContext is EFCustomerContext custCtx && custCtx.Customers.Count() == 0)
                {
                    custCtx.Customers.AddRange(Customers);
                }
            }

            dbContext.SaveChanges();
        }

        /// <summary>
        /// Удаление данных из БД
        /// </summary>
        public static void ClearData(DbContext dbContext)
        {
            if (dbContext is EFDatabaseContext prodCtx && prodCtx.Products.Count() > 0)
            {
                prodCtx.Products.RemoveRange(prodCtx.Products);
            }
            else if (dbContext is EFCustomerContext custCtx && custCtx.Customers.Count() > 0)
            {
                custCtx.Customers.RemoveRange(custCtx.Customers);
            }

            dbContext.SaveChanges();
        }

        private static Product[] Products =
        {
            new Product {Name = "Car-1", Category = "SportCars", Price = 10, Colors = Colors.Green, InStock = true},
            new Product {Name = "Car-2", Category = "SportCars", Price = 15, Colors = Colors.Red, InStock = true},
            new Product {Name = "Car-3", Category = "Cars", Price = 5, Colors = Colors.Blue, InStock = false},
            new Product {Name = "Car-4", Category = "cars", Price = 7, Colors = Colors.Red, InStock = true}
        };

        private static Customer[] Customers =
        {
            new Customer {Name = "User-1", City = "City-1", Country = "Country-1"},
            new Customer {Name = "User-2", City = "City-2", Country = "Country-2"},
            new Customer {Name = "User-3", City = "City-3", Country = "Country-3"}
        };
    }
}