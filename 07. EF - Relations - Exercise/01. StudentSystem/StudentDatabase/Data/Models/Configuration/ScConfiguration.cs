namespace StudentDatabase.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using StudentDatabase.Data.Models;

    public class ScConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.ToTable("StudentCourses");

           builder.HasKey(sc => new { sc.CourseId, sc.StudentId });


            builder.HasOne(sc => sc.Course)
                .WithMany(sc => sc.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            builder.HasOne(sc => sc.Student)
                .WithMany(sc => sc.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

                
        }
    }
}
