namespace BettingSysDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(p => p.PositionId);

            builder.Property(p => p.Name)
                    .IsRequired()
                    .IsUnicode();

            builder.HasMany(p => p.Players)
                   .WithOne(p => p.Position);
        }
    }
}
