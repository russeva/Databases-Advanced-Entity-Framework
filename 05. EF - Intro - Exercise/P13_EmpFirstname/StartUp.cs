using P02_DatabaseFirst.Data;
using System;
using System.Linq;
using System.Text;

namespace P13_EmpFirstname
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                var employeesFiltered = db.Employees
                                          .Where(x => x.FirstName.Substring(0,2) == "Sa")
                                          .Select(x => new
                                          {
                                              x.FirstName,
                                              x.LastName,
                                              x.Salary,
                                              x.JobTitle
                                          })
                                          .OrderBy(x => x.FirstName)
                                          .ThenByDescending(x => x.LastName)
                                          .ToList();

                foreach (var entry in employeesFiltered)
                {
                    Console.WriteLine($"{entry.FirstName} {entry.LastName} - {entry.JobTitle} - (${entry.Salary:f2})");
                }
            }
        }
    }
}
