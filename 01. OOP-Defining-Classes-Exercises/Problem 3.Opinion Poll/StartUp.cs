using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3.Opinion_Poll
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> aboveThirty = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] currentEntry = Console.ReadLine().Split();
                Person currentPerson = new Person()
                {
                    Name = currentEntry[0],
                    Age = int.Parse(currentEntry[1])
                };

                if (currentPerson.Age > 30)
                {
                    aboveThirty.Add(currentPerson);
                }
            }
            Console.WriteLine();
            
            foreach (Person person in aboveThirty.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
