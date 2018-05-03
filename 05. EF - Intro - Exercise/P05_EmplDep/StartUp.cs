using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P05_EmplDep
{
    class StartUp
    {
        static void Main(string[] args)

        {


            /* 5.Employees from Research and Development */

            using (SoftUniContext db = new SoftUniContext())
            {
                var dbExtract = db.Employees
                    .Where(x => x.Department.Name == "Research and Development")
                    .OrderBy(x => x.Salary)
                    .OrderByDescending(x => x.FirstName)
                    .Select(x => new { x.FirstName, x.LastName, DepartmentName = x.Department.Name, x.Salary })
                    .ToList();

                foreach (var entry in dbExtract)
                {
                    Console.WriteLine($"{entry.FirstName} {entry.LastName} from {entry.DepartmentName} - ${entry.Salary:f2}");



                }
            }
        }
    }
}

