namespace SalesDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(s => s.StoreId);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .IsUnicode()
                   .HasMaxLength(80);

            builder.HasMany(s => s.Sales)
                   .WithOne(s => s.Store);
        }
    }
}
