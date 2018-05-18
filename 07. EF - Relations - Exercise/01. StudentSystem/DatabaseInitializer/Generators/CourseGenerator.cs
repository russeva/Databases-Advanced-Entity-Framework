

namespace DatabaseInitializer.Generators
{
    using System;

    using StudentDatabase.Data.Models;

    public static class CourseGenerator
    {
        private static string[] nameList = {
            "C# - introducing course",
        "Java - introducing course",
        "PHP - introducing course",
        "Kotlin - Introducing course",
        "C++ - introducing course",
        "Go - introducing course",
        "C - introducing course",
        "Objective-C introducing course",
        "Machine learning - introducing course",
        "Unity - introducing course",
        "MySQL - basics course",
        "Data structures - course",
        "Arduino  basics",
        "QA Automation",
        "NativeScript Development",
        "Game Development Fundamentals",
        };

        private static string[] descriptionList = {
            "Intensive development course",
            "Intensive introduction into the basics",
            "Learn the fundamentals",
            "Suitable course for begginers",
            
        };

        private static DateTime[] endDates = {
            new DateTime(2018-06-24),
            new DateTime(2018-07-26),
            new DateTime(2018-08-24),
            new DateTime(2018-09-28),
            new DateTime(2018-10-30),
            new DateTime(2018-07-31),
            new DateTime(2018-08-30),
        };

        private static DateTime[] startDates = {
            new DateTime(2018-02-24),
            new DateTime(2018-02-26),
            new DateTime(2018-03-24),
            new DateTime(2018-04-28),
            new DateTime(2018-13-30),
            new DateTime(2018-02-31),
            new DateTime(2018-04-30),
        };

        private static double[] priceList = {
            129.99,
            119.99,
            99.99,
        };

        public static Course GenerateCourse()
        {
            Course newCourse = new Course()
            {
                Name = GenerateName(),
                Description = GenerateDescription(),
                StartDate = GenerateStartDate(),
                EndDate = GenerateEndDate(),
                Price = GeneratePrice(),
                  
            };

            return newCourse;
        }

        private static double GeneratePrice()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, priceList.Length);
            double currentPrice = priceList[index];

            return currentPrice;
        }

        private static string GenerateName()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, nameList.Length);
            string currentName = nameList[index];

            return currentName;
        }

        private static DateTime GenerateEndDate()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, endDates.Length);
            DateTime currentEndDate = endDates[index];

            return currentEndDate;
        }

        private static DateTime GenerateStartDate()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, startDates.Length);
            DateTime currentStartDate = startDates[index];

            return currentStartDate;
        }

        private static string GenerateDescription()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, descriptionList.Length);
            string currentDescription = descriptionList[index];

            return currentDescription;
        }
    }
}
