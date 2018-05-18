namespace DatabaseInitializer.Generators
{
    using System;
    using StudentDatabase.Data.Models;
 
    public static class StudentGenerator 
    {
        private static string[] firstName = {"Anna-Maria", "Lucy", "Danielle", "Stewie", "Roger", "Luca", "Martin", "Christian", "Debora",
        "Eliza", "Yuka", "Kazu", "Chloe", "Snezhana", "Puffa"};

        private static string[] number = {"0712849376", "0736389902", "0763339273", "0774192800", "0736926384","0793719997",
        "0753392074","0772911047", "0238715930","0772947291"};

        private static DateTime[] birthday = {
            new DateTime(1991-02-25),
            new DateTime(1975-10-01),
            new DateTime(1998-06-19),
            new DateTime(1986-08-24),
            new DateTime(1992-05-31),
            new DateTime(1982-11-16),
            new DateTime(1973-03-21),
            new DateTime(1968-10-31),
            new DateTime(1979-01-22),
            new DateTime(1990-07-13)
        };



        public static Student GenerateStudent()
        {
            Student newStudent = new Student()
            {
                Name = GenerateName(),
                PhoneNumber = GeneratePhoneNumber(),
                Birthday = GenerateBirthday()
            };
            return newStudent;
           
        }

        private static DateTime? GenerateBirthday()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, birthday.Length);
            DateTime currentBirthday = birthday[index];

            return currentBirthday;
        }

        private static string GeneratePhoneNumber()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, number.Length);
            string currentNumber = number[index];

            return currentNumber;
        }

        private static string GenerateName()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, firstName.Length);
            string currentName = firstName[index];

            return currentName;
        }
    }
}
