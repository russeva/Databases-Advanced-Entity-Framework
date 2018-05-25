namespace BettingSysDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UderId);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .IsUnicode();

            builder.Property(u => u.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

            builder.Property(u => u.Password)
                   .IsRequired();

            builder.Property(u => u.Username)
                   .IsRequired();

            builder.HasMany(u => u.Bets)
                   .WithOne(u => u.User);
        }
    }
}
