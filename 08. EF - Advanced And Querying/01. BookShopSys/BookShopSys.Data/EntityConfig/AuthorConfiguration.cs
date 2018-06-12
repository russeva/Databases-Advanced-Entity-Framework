namespace BookShopSys.Data.EntityConfig
{
    using BookShopSys.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.AuthorId);

            builder.Property(a => a.FirstName)
                .IsUnicode()
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(a => a.LastName)
                .IsUnicode()
                .HasMaxLength(50)
                .IsRequired();

            
                
        }
    }
}
