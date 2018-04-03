using System;
using System.Collections.Generic;

namespace _3.Validation_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArrgs = Console.ReadLine().Split();
                string firstName = cmdArrgs[0];
                string lastName = cmdArrgs[1];
                int age = int.Parse(cmdArrgs[2]);
                double salary = double.Parse(cmdArrgs[3]);

                Person currentPerson = new Person(firstName, lastName, age, salary);

                people.Add(currentPerson);
            }
        }
    }
}
