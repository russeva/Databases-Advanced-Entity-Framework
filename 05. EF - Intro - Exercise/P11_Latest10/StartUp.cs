using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P11_Latest10
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext db = new SoftUniContext())
            {
                var latestProjects = db.Projects
                                       .Select(x => new
                                       {
                                           Name = x.Name,
                                           Description = x.Description,
                                           StartDate = x.StartDate
                                       })
                                       .OrderByDescending(x => x.StartDate)
                                       .Take(10)
                                       .OrderBy(x => x.Name)
                                       .ToList();
                

                foreach (var entry in latestProjects)
                {
                    Console.WriteLine($"{entry.Name} ");

                    Console.WriteLine($"{entry.Description}");

                    Console.WriteLine($"{entry.StartDate}");
                   
                }
            }
        }
    }
}
