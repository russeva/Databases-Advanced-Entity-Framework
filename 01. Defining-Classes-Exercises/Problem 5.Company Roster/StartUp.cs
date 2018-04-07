using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5.Company_Roster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> employeeDB = new List<Employee>();
            Dictionary<string, double> departmentSalary = new Dictionary<string, double>();

            for (int i = 0; i < n; i++)
            {
                string[] currentEntry = Console.ReadLine().Split();
                string name = currentEntry[0];
                double salary = double.Parse(currentEntry[1]);
                string position = currentEntry[2];
                string department = currentEntry[3];
                string email;
                int age;

                if (currentEntry[4].Contains('@'))
                {
                    email = currentEntry[4];
                }
                else
                {
                    email = "n/a";
                }
                
                var lastElement = currentEntry[currentEntry.Length - 1];

                if (int.TryParse(lastElement, out int currentAge))
                {
                    age = currentAge;
                }
                else
                {
                    age = -1;
                }

                Employee currentEmployee = new Employee(name, salary, position, department, email, age);

                employeeDB.Add(currentEmployee);
                if (!departmentSalary.ContainsKey(department))
                {
                    departmentSalary[department] = salary;
                }
                else
                {
                    departmentSalary[department] += salary;
                }
                
            }
            var ordered = employeeDB
                         .GroupBy(x => x.Department)
                         .Select(x => new {Department = x.Key,
                                  AvgSalary = x.Average( emp=> emp.Salary),
                                   Empls = x.OrderByDescending(emp => emp.Salary)})
                         .ToList()
                         .OrderByDescending(e => e.AvgSalary)
                         .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {ordered.Department}");
            foreach (var empl in ordered.Empls)
            {
                Console.WriteLine($"{empl.Name} {empl.Salary:f2} {empl.Email} {empl.Age}");
            }


        }
    }
}
