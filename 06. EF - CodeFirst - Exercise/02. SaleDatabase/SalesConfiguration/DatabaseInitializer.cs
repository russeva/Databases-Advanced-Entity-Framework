namespace DatabaseConfiguration
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using SalesDatabase;
    using SalesDatabase.Data.Models;

    public class  DatabaseInitializer
    {
        public static void Seed(SalesDbContext context)
        {
            var customerList = new[]
            {
                new Customer
             {
                Name = "Peter",
                Email = "zitrone@lime.bg",
                CreditCardNumber = "428730028299"
                },
                new Customer
            {
                Name = "Stacy",
                Email = "stace338@gmail.com",
                CreditCardNumber = "123945029110"
            },
                new Customer
                {
                    Name = "George",
                    Email = "dirtyink@abv.bg",
                    CreditCardNumber = "293002582291"
                }
            };

            context.AddRange(customerList);
            context.SaveChanges();

            var productList = new[]
            {
                new Product
                {
                    Name = "Suede Leather Jacket",
                    Quantity = 1,
                    Price = 59.99,
                },
                 new Product
                {
                    Name = "Ripped Jeans",
                    Quantity = 2,
                    Price = 19.95,
                },
                  new Product
                {
                    Name = "Leather Cap with logo",
                    Quantity = 1,
                    Price = 29.90,
                }

            };

            context.AddRange(productList);
            context.SaveChanges();

            var storeList = new[]
            {
                new Store
                {
                    Name = "Loco Po",
                },
                new Store
                {
                    Name = "Sweet18"
                },
                new Store
                {
                    Name = "Paranoia"
                }
            };

            context.AddRange(storeList);
            context.SaveChanges();

            var saleList = new[]
            {
                new Sale
                {
                    ProductId = 1,
                    CustomerId = 2,
                    StoreId = 1,
                },
                new Sale
                {
                    ProductId = 2,
                    CustomerId = 3,
                    StoreId = 3
                },
                new Sale
                {
                    ProductId = 3,
                    CustomerId = 2,
                    StoreId = 1
                }

            };

            context.AddRange(saleList);
            context.SaveChanges();

        }

    }
}
