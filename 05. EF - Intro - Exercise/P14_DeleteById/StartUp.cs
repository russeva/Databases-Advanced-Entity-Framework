using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P14_DeleteById
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SoftUniContext db = new SoftUniContext())
            {
               
                var emProjects = db.EmployeesProjects
                                   .Where(x => x.ProjectId == 2)
                                   .ToList();

                
                foreach (var entry in emProjects)
                {
                    db.EmployeesProjects.Remove(entry);
                }
                
               
                var project = db.Projects.Find(2);
                db.Projects.Remove(project);

                
                db.SaveChanges();

                var tenProjects = db.Projects
                                    .Take(10)
                                    .Select(x => x.Name)
                                    .ToList();

                foreach (var pro in tenProjects)
                {
                    Console.WriteLine(pro);
                }
            }
        }
    }
}
