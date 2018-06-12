namespace BookShopSys.Data.EntityConfig
{
    using BookShopSys.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BookCategoriesConfig : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.HasKey(bc => new { bc.BookId, bc.CategoryId });

            builder.HasOne(bc => bc.Book)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(bc => bc.BookId);

            builder.HasOne(bc => bc.Category)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);
                
        }
    }

}
