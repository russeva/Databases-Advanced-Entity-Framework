namespace StudentDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        public int CourseId { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }

        public ICollection<Resource> Resources { get; set; } = new HashSet<Resource>();
        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public ICollection<HomeworkSubmission> HomeworkSubmissions { get; set; } = new HashSet<HomeworkSubmission>();
    }
}
