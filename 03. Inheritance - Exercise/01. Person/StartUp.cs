using System;

namespace _01._Person
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            try
            {
                Person currentPerson = new Person(name, age);
                Console.WriteLine(currentPerson.ToString());
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            string child = Console.ReadLine();
            int childAge = int.Parse(Console.ReadLine());

            try
            {
                Child currentChild = new Child(name, age);
                Console.WriteLine(currentChild.ToString());    
            }
            catch (ArgumentException notOldEnough)
            {

                Console.WriteLine(notOldEnough.Message); ;
            }
        }
    }
}
