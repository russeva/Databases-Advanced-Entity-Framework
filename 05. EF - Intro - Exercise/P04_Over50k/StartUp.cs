using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P04_Over50k
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext db = new SoftUniContext();

            /*P04_Employees with Salary Over 50 000*/
            var over50kSalary = db.Employees
                                  .Where(e => e.Salary > 50000)
                                  .Select(e => new { e.FirstName })
                                  .OrderByDescending(e => e)
                                  .ToList();

            foreach (var entry in over50kSalary.OrderBy(x => x.FirstName))
            {
                Console.WriteLine($"{entry.FirstName}");
            }

        }
    }
}
