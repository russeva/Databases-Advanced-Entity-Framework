namespace StudentStartUp
{
    using System;
    using StudentDatabase;
    using DatabaseInitializer;

    class StartUp
    {
        static void Main(string[] args)
        {
            using (StudentDbContext db = new StudentDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                DatabaseInitializer.RandomSeed(db);
                

            }
        }
    }
}
