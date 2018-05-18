namespace StudentDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .IsUnicode()
                   .HasMaxLength(80);

            builder.Property(c => c.Description)
                   .IsRequired(false)
                   .IsUnicode();

            builder.Property(c => c.StartDate)
                   .HasColumnType("DATETIME2");

            builder.Property(c => c.EndDate)
                   .HasColumnType("DATETIME2");



        }
    }
}
