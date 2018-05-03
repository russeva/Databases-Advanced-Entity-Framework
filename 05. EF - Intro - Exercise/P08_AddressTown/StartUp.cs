using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System;
using System.Linq;

namespace P08_AddressTown
{
    class StartUp
    {
        static void Main(string[] args)
        {

            using (SoftUniContext db = new SoftUniContext())
            {
                var adressByTown = db.Addresses
                                     .Select(e => new
                                     {
                                         AdressText = e.AddressText,
                                         Town = e.Town.Name,
                                         EmployeeCount = e.Employees.Count
                                     })
                                     .OrderByDescending(x => x.EmployeeCount)
                                     .ThenBy(x => x.Town)
                                     .ThenBy(x => x.AdressText)
                                     .Take(10);
                                    

                foreach (var entry in adressByTown)
                {
                    Console.WriteLine($"{entry.AdressText}, {entry.Town} - {entry.EmployeeCount} employees");
                }
            }
        }
    }
}
