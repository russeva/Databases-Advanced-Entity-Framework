using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System;
using System.Linq;

namespace P10_Departments
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                var employees = db.Departments
                                  .Where(x => x.Employees.Count() > 5)
                                  .Select(x => new
                                  {
                                      EmployeeCount = x.Employees.Count(),
                                      DepartmentName = x.Name,
                                      ManagersName = $"{x.Manager.FirstName} {x.Manager.LastName}",
                                      JobEmployee = db.Employees.Select(e => new
                                      {
                                          Job = e.JobTitle,
                                          FirstName = $"{e.FirstName}",
                                          LastName = $"{e.LastName}"
                                      })
                                  })
                                  .OrderBy(x => x.EmployeeCount)
                                  .ThenBy(x => x.DepartmentName)
                                  .ToList();

                foreach (var entry in employees)
                {
                    Console.WriteLine($"{entry.DepartmentName} - {entry.ManagersName}");
                    var sorted = db.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
                    foreach (var e in sorted)
                    {
                        Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                    }
                    Console.WriteLine("----------");
                }
            }
        }
    }
}
