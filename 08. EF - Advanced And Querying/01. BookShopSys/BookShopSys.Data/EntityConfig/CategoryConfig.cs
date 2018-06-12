namespace BookShopSys.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using BookShopSys.Data.Models;

    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);

            builder.Ignore(c => c.BookCategories);

            builder.Property(c => c.Name)
                .IsUnicode()
                .HasMaxLength(50);

        }
    }
}
