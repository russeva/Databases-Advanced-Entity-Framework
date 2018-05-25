namespace BettingSysDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.TeamId);

            builder.Property(t => t.Initials)
                   .HasColumnType("CHAR(3)")
                   .IsUnicode();

            builder.Property(t => t.Name)
                   .IsRequired()
                   .IsUnicode();

            builder.HasOne(t => t.PrimaryKitColor)
                   .WithMany(t => t.PrimaryKitColorTeams)
                   .HasForeignKey(t => t.PrimaryKitColorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.SecondaryKitColor)
                   .WithMany(t => t.SecondaryKitColorTeams)
                   .HasForeignKey(t => t.SecondaryKitColorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Town)
                   .WithMany(t => t.Teams);


            builder.HasMany(t => t.Player)
                   .WithOne(t => t.Team);


            builder.HasMany(t => t.AwayGames)
                   .WithOne(t => t.AwayTeam)
                   .HasForeignKey(t => t.AwayTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.HomeGames)
                   .WithOne(t => t.HomeTeam)
                   .HasForeignKey(t => t.HomeTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
