namespace BettingSysDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(g => g.GameId);

            builder.Property(g => g.DateTime)
                   .HasColumnType("DATETIME2")
                   .HasDefaultValueSql("GETDATE()");

            builder.HasMany(g => g.Bets)
                   .WithOne(g => g.Game);

            builder.HasMany(g => g.PlayerStatistics)
                   .WithOne(g => g.Game);

        }
    }
}
