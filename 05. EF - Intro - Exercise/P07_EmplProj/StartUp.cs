
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System;
using System.Globalization;
using System.Linq;

namespace P07_EmplProj
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                var query = db.Employees
                    .Where(e => e.EmployeesProjects.Any(
                        ep => ep.Project.StartDate.Year >= 2001 &&
                               ep.Project.StartDate.Year <= 2003))
                    .Take(30)
                    .Select(x =>
                   new
                   {
                       Name = $"{x.FirstName} {x.LastName}",
                       Manager = $"{x.Manager.FirstName} {x.Manager.LastName}",
                       Projects = db.EmployeesProjects.Select(p => new
                       {
                           p.Project.Name,
                           p.Project.StartDate,
                           p.Project.EndDate
                       })
                   })
                       .ToList();


                foreach (var emp in query)
                {
                    Console.WriteLine($"{emp.Name} - Manager: {emp.Manager}");

                    foreach (var pr in emp.Projects)
                    {
                        Console.Write($"--{pr.Name} - {pr.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - ");
                        if (pr.EndDate == null)
                        {
                            Console.WriteLine("not finished");
                        }
                        else
                        {
                            Console.WriteLine(pr.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
                        }
                    }
                }
            }

        }
    }
}


