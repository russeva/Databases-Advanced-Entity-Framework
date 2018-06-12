namespace BookShopSys.Data.EntityConfig
{
    using BookShopSys.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId);

            builder.Property(b => b.Title)
                .IsUnicode()
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.Description)
                .IsUnicode()
                .HasMaxLength(1000);

            builder.Property(b => b.ReleaseDate)
                .IsRequired(false);

            builder.Ignore(b => b.BookCategories);

            builder.HasOne(b => b.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.AuthorId);
            
        }
                
    }
}

