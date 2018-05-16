namespace SalesDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .IsUnicode()
                   .HasMaxLength(100);

            builder.Property(c => c.Email)
                   .IsRequired()
                   .IsUnicode(false)
                   .HasMaxLength(80);

            builder.HasMany(c => c.Sales)
                   .WithOne(c => c.Customer);
        }
    }
}
