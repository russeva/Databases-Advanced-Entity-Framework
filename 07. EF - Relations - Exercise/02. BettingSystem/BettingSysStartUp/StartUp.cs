namespace BettingSysStartUp
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using BettingSysDatabase;
    
    class StartUp
    {
        static void Main(string[] args)
        {
            using (BettingSysDbContext db = new BettingSysDbContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}
