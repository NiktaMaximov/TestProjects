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
                    prodCtx.Set<Shipment>().AddRange(Shipments);
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
                prodCtx.Set<Shipment>().RemoveRange(Shipments);
            }
            else if (dbContext is EFCustomerContext custCtx && custCtx.Customers.Count() > 0)
            {
                custCtx.Customers.RemoveRange(custCtx.Customers);
            }

            dbContext.SaveChanges();
        }

        public static Shipment[] Shipments
        {
            get
            {
                return new Shipment[]{
                    new Shipment {ShipperName = "ShipperName_1", StartCity = "StartCity_1", EndCity = "EndCity_1"},
                    new Shipment {ShipperName = "ShipperName_2", StartCity = "StartCity_2", EndCity = "EndCity_2"},
                    new Shipment {ShipperName = "ShipperName_3", StartCity = "StartCity_3", EndCity = "EndCity_3"},
                };
            }
        }

        private static Product[] Products
        {
            get
            {
                Product[] products = new Product[]
                {
                    new Product { Name = "Car-1", Category = "SportCars", Price = 10, Colors = Colors.Green, InStock = true },
                    new Product { Name = "Car-2", Category = "SportCars", Price = 15, Colors = Colors.Red, InStock = true },
                    new Product { Name = "Car-3", Category = "Cars", Price = 5, Colors = Colors.Blue, InStock = false },
                    new Product { Name = "Car-4", Category = "Cars", Price = 7, Colors = Colors.Red, InStock = true }
                };

                ConcatLocation hq = new ConcatLocation { LocationName = "LocationName-1", Address = "Address-1" };

                ConcatDetails bob = new ConcatDetails { Name = "Bob", Phone = "799-999-999", Location = hq };

                Supplier acme = new Supplier { Name = "Name-0", City = "City-0", State = "State-0", Concat = bob };

                Supplier s1 = new Supplier { Name = "Name-1", City = "City-1", State = "State-1" };
                Supplier s2 = new Supplier { Name = "Name-2", City = "City-2", State = "State-2" };

                //products.First().Supplier = s1;

                //foreach (var item in products.Where(p => p.Category == "SportCars"))
                //{
                //    item.Supplier = s2;
                //}

                foreach(Product p in products)
                {
                    if (p == products[0])
                        p.Supplier = s1;
                    else if (p.Category == "SportCars")
                        p.Supplier = s2;
                    else
                        p.Supplier = acme;
                }

                return products;
            }
        }

        private static Customer[] Customers =
        {
            new Customer {Name = "User-1", City = "City-1", Country = "Country-1"},
            new Customer {Name = "User-2", City = "City-2", Country = "Country-2"},
            new Customer {Name = "User-3", City = "City-3", Country = "Country-3"}
        };
    }
}