using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P12_Salary
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                var increasedSalaries = db.Employees
                                          .Where(x => x.Department.Name == "Engineering" ||
                                                 x.Department.Name == "Tool Design" ||
                                                 x.Department.Name == "Marketing" ||
                                                 x.Department.Name  == "Information Services")
                                          .ToList();
                
                foreach (var entry in increasedSalaries)
                {
                    entry.Salary *= 1.12m;
                    
                }
                db.SaveChanges();

                var sorted = increasedSalaries.OrderBy(x => x.FirstName).ThenBy(e => e.LastName);
               
                foreach (var entry in increasedSalaries)
                {
                    Console.WriteLine($"{entry.FirstName} {entry.LastName} {entry.Salary:f2}");

                }
            }
        }
    }
}
