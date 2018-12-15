namespace CarDealer.Data
{
    
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;
    using System;

    using CarDealer.Models;
    using CarDealer.Data.EntityConfig;

    public class CarDealerDbContext : DbContext
    {
        public CarDealerDbContext()
        { }

        public CarDealerDbContext(DbContextOptions options) 
            :base(options)
        {}

        public DbSet<Car> Cars { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<PartCars> PartCars { get; set; }

        public DbSet<Sale> Sale { get; set; }

        public DbSet<Supplier> Supplier { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);

                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfig());

            modelBuilder.ApplyConfiguration(new CustomerConfig());

            modelBuilder.ApplyConfiguration(new PartConfig());

            modelBuilder.ApplyConfiguration(new PartCarConfig());

            modelBuilder.ApplyConfiguration(new SaleConfig());

            modelBuilder.ApplyConfiguration(new SupplierConfig());
        }
    }
}
