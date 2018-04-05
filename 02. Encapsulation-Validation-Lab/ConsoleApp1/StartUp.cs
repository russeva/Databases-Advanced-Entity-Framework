using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string firstName = cmdArgs[0];
                string lastName = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);
                Person currentPerson = new Person(firstName,lastName,age);
                people.Add(currentPerson);
            }

            people.OrderBy(x => x.firstName)
                  .ThenBy(x => x.Age)
                  .ToList();

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
