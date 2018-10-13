namespace Shop.Data
{
    
    using Microsoft.EntityFrameworkCore;
    using Shop.Data.EntityConfig;
    using Shop.Models;
    using System;

    public class ShopDbContext : DbContext

    {
        public ShopDbContext()
        { }

        public ShopDbContext(DbContextOptions options) 
            : base(options)
        {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProducts> CategorieProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryProductConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
    }
}
