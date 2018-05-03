using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P15_RemoveTowns
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputTown = Console.ReadLine();

            using (SoftUniContext db = new SoftUniContext())
            {
                var townId = db.Towns
                               .Where(x => x.Name == inputTown)
                               .Select(x =>  x.TownId)
                               .SingleOrDefault();


                var employeesList = db.Employees
                                      .Where(x => x.Address.TownId == townId)
                                      .Select(x => x)
                                      .ToList();

                foreach (var employee in employeesList)
                {
                    employee.AddressId = null;
                }
                db.SaveChanges();


                var townAdress = db.Addresses
                                   .Where(x => x.TownId == townId)
                                   .ToList();
                int counter = 0;

                foreach (var entry in townAdress)
                {
                    db.Addresses.Remove(entry);
                    counter++;
                }

                db.SaveChanges();

                Console.WriteLine($"{counter} address in {inputTown} was deleted");

            
            }
        }
    }
}
