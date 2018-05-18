namespace StudentDatabase
{
    using Microsoft.EntityFrameworkCore;

    using StudentDatabase.Data;
    using StudentDatabase.Data.Models;
    using StudentDatabase.Data.Models.Configuration;

    public class StudentDbContext : DbContext
    {
        public StudentDbContext()
        { }

        public StudentDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<HomeworkSubmission> HomeworksSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new HomeworkSubmissionConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceConfiguration());
            modelBuilder.ApplyConfiguration(new ScConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());

        }
    }
}
