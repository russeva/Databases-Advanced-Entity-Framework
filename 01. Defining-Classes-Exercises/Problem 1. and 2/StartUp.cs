using System;
using System.Reflection;

namespace _01._DB_Advanced_OOP_Defining_Classes_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Type personType = typeof(Person);
                PropertyInfo[] properties = personType.GetProperties
                    (BindingFlags.Public | BindingFlags.Instance);
                Console.WriteLine(properties.Length);

                Person currentPerson = new Person();
                currentPerson.Name = "Pesho";
                currentPerson.Age = 20;

                Person anotherPerson = new Person("Gosho", 12);
                Console.WriteLine(anotherPerson.Name);
                Console.WriteLine(anotherPerson.Age);

                Person lastPerson = new Person();
                Console.WriteLine(lastPerson.Name);
                Console.WriteLine(lastPerson.Age);
               
            

            }
        }
    }
}
