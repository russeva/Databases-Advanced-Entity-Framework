namespace SalesDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .IsUnicode()
                   .HasMaxLength(50);

            builder.Property(p => p.Description)
                   .HasMaxLength(250)
                   .HasDefaultValue("No Description");

            builder.HasMany(p => p.Sales)
                   .WithOne(p => p.Product);
        }
    }
}
