namespace BookShopSys.Data.Initializer
{
    using System;

    using BookShopSys.Data;
    using BookShopSys.Data.Models;
    using BookShopSys.Data.Initializer.Generators;

    public class DbInitializer
    {
        public static void ResetDatabase(BookShopSysDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("BookShop database created successfully.");

            Seed(context);
        }

        public static void Seed(BookShopSysDbContext context)
        {
            Book[] books = BookGenerator.CreateBooks();

            context.Books.AddRange(books);

            context.SaveChanges();

            Console.WriteLine("Sample data inserted successfully.");
        }
    }
}
