namespace StudentDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HomeworkSubmissionConfiguration : IEntityTypeConfiguration<HomeworkSubmission>
    {
        public void Configure(EntityTypeBuilder<HomeworkSubmission> builder)
        {
            builder.HasKey(hs => hs.HomeworkId);

            builder.Property(hs => hs.Content)
                   .IsUnicode(false);

            builder.Property(hs => hs.SubmissionTime)
                .HasColumnType("DATETIME2")
                    .HasDefaultValueSql("GETDATE()");

            builder.HasOne(hs => hs.Student)
                .WithMany(hs => hs.HomeworkSubmissions)
                .HasForeignKey(hs => hs.StudentId);
                   

            builder.HasOne(hs => hs.Course)
                .WithMany(hs => hs.HomeworkSubmissions)
                .HasForeignKey(hs => hs.CourseId);

            builder.HasOne(hs => hs.Student)
                   .WithMany(hs => hs.HomeworkSubmissions)
                   .HasForeignKey(hs => hs.StudentId);

            
        }
    }
}
