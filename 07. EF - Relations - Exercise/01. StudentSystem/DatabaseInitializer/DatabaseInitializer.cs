namespace DatabaseInitializer
{
    using System;
    using global::DatabaseInitializer.Generators;
    using StudentDatabase;
    using StudentDatabase.Data;
    using StudentDatabase.Data.Models;
    
    

    public static class DatabaseInitializer
    {
        public static void RandomSeed(StudentDbContext context)
        {

            for (int i = 0; i < 100; i++)
            {
                context.Add(StudentGenerator.GenerateStudent());
                context.Add(CourseGenerator.GenerateCourse());
                context.Add(ResourceGenerator.GenerateResource());

                context.SaveChanges();
            }


            
        }
    }
}
