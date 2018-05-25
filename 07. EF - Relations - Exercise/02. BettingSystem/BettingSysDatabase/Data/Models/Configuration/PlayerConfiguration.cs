namespace BettingSysDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(p => p.PlayerId);

            builder.Property(p => p.Name)
                   .IsUnicode()
                   .IsRequired();

            builder.HasMany(p => p.PlayerStatistics)
                   .WithOne(p => p.Player);
        }
    }
}
