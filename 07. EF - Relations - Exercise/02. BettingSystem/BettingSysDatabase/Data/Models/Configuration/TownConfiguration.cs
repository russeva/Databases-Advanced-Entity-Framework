namespace BettingSysDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasKey(t => t.TownId);

            builder.Property(t => t.Name)
                   .IsRequired()
                   .IsUnicode();

            builder.HasMany(t => t.Teams)
                   .WithOne(t => t.Town);
        }
    }
}
