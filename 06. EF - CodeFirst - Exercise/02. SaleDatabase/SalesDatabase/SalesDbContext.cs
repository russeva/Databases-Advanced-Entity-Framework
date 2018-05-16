namespace SalesDatabase
{
    using System;
    using Microsoft.EntityFrameworkCore;
    
    using SalesDatabase.Data.Models;
    using SalesDatabase.Data.Models.Configuration;

    public class SalesDbContext : DbContext
    {
        public SalesDbContext()
        {}

        public SalesDbContext(DbContextOptions options)
            :base(options)
        {}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfiguration(new SaleConfiguration());

            modelBuilder.ApplyConfiguration(new StoreConfiguration());
        }
    }
}
