namespace BettingSysDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PSConfigurqation : IEntityTypeConfiguration<PlayerStatistics>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistics> builder)
        {
            builder.HasKey(ps => new { ps.PlayerId, ps.GameId });

            builder.HasOne(ps => ps.Player)
                   .WithMany(ps => ps.PlayerStatistics);


            builder.HasOne(ps => ps.Game)
                   .WithMany(ps => ps.PlayerStatistics);
        }
    }
}
