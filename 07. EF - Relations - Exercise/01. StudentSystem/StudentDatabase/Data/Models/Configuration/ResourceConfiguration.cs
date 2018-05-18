namespace StudentDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(r => r.ResourceId);

            builder.Property(r => r.Name)
                   .IsRequired()
                   .IsUnicode()
                   .HasMaxLength(50);

            builder.Property(r => r.Url)
                   .IsUnicode(false);

            builder.HasOne(r => r.Course);
        }
    }
}
