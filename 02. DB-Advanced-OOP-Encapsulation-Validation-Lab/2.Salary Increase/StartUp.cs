using System;
using System.Collections.Generic;

namespace _2.Salary_Increase
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> employeeDB = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArggs = Console.ReadLine().Split();
                string firstName = cmdArggs[0];
                string lastName = cmdArggs[1];
                int age = int.Parse(cmdArggs[2]);
                double salary = double.Parse(cmdArggs[3]);

                Person currentPerson = new Person(firstName, lastName, age, salary);
                employeeDB.Add(currentPerson);
            }

            int bonus = int.Parse(Console.ReadLine());
            foreach (var employee in employeeDB)
            {
                employee.IncreaseSalary(bonus);
                Console.WriteLine(employee.ToString());
            }
        }
    }
}
