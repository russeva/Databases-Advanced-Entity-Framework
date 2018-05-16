namespace SalesDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.SaleId);

            builder.Property(s => s.Date)
                   .HasColumnType("DATETIME2")
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(s => s.Customer);
            builder.HasOne(s => s.Product);
            builder.HasOne(s => s.Store);
        }
    }
}
