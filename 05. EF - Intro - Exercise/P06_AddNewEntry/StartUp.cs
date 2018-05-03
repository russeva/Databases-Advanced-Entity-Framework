using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System;
using System.Linq;

namespace P06_AddNewEntry
{
    class StartUp
    {
        static void Main(string[] args)
        {
            /* 6.Adding a New Address and Updating Employee */

            using (var db = new SoftUniContext())
            {
                Address newAdress = new Address()
                {
                    TownId = 4,
                    AddressText = "Vitoshka 15"
                };

                Employee newEntry = null;
                newEntry = db.Employees
                    .Where(x => x.LastName == "Nakov")
                    .FirstOrDefault();
                newEntry.Address = newAdress;

                db.SaveChanges();
                    
            }
        }
    }
}
