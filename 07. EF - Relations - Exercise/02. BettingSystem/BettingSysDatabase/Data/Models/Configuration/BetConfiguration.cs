namespace BettingSysDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(b => b.BetId);

            builder.Property(b => b.DateTime)
                   .HasColumnType("DATETIME2")
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(b => b.Game)
                   .WithMany(b => b.Bets);

            builder.HasOne(b => b.User)
                   .WithMany(b => b.Bets);
        }
    }
}
