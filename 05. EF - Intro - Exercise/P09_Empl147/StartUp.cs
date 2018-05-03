using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System;
using System.Linq;

namespace P09_Empl147
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                var employee = db.Employees
                    .Where(e => e.EmployeeId == 147)
                    .Select(e => new
                    {
                        Name = $"{e.FirstName} {e.LastName}",
                        Job = e.JobTitle,
                        Projects = db.Projects.Select(p => new { p.Name })
                    })
                    .SingleOrDefault();

                Console.WriteLine($"{employee.Name} - {employee.Job}");
                foreach (var pr in employee.Projects)
                {
                    Console.WriteLine($"{pr.Name}");
                }
            }
        }
    }
}
