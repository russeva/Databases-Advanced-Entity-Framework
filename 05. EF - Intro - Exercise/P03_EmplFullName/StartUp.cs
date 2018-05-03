
using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P03_EmplFullName
{
    class StartUp
    {
        static void Main(string[] args)
        {

            /*P03_Employees Full information*/
            SoftUniContext db = new SoftUniContext();

            var employeesFullInfo = db.Employees
                                      .Select(x => new { x.FirstName, x.LastName, x.MiddleName, x.JobTitle, x.Salary })
                                      .ToList();

            foreach (var entry in employeesFullInfo)
            {
                Console.WriteLine($"{entry.FirstName} {entry.LastName} {entry.MiddleName} {entry.JobTitle} {entry.Salary:f2}");
            }
        }
    }
}
