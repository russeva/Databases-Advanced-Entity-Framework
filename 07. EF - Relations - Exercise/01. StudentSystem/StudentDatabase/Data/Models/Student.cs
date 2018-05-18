namespace StudentDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public ICollection<HomeworkSubmission> HomeworkSubmissions { get; set; } = new HashSet<HomeworkSubmission>();
    }
}
