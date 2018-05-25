namespace BettingSysDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.CoutnryId);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .IsUnicode()
                   .HasMaxLength(50);

            builder.HasMany(c => c.Town)
                   .WithOne(c => c.Country);
        }
    }
}
