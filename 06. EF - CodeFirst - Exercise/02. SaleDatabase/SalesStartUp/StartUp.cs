namespace SalesStartUp
{
    using System;
    
    using SalesDatabase;
    using SalesDatabase.Data.Models;
    using DatabaseConfiguration;
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SalesDbContext db = new SalesDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                
                DatabaseInitializer.Seed(db);
            }
        }

     
    }

}

