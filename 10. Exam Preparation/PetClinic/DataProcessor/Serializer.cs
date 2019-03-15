namespace PetClinic.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context.Animals
                .Where(a => a.Passport.OwnerPhoneNumber == phoneNumber)
                .Select(x => new ExportAnimalsByOwner()
                {
                    AnimalName = x.Name,
                    OwnerName = x.Passport.OwnerName,
                    Age = x.Age,
                    SerialNumber = x.Passport.SerialNumber,
                    RegisteredOn = x.Passport.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                })
                .OrderBy(x => x.Age)
                .ThenBy(x => x.SerialNumber)
                .ToList();

            string jsonString = JsonConvert.SerializeObject(animals, Formatting.Indented);
            File.WriteAllText("../../../bin/Debug/netcoreapp2.0/Results/Resultscategories-by-product.json", jsonString);

            return jsonString;
           
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context.Procedures
                .Select(x => new ExportProceduresDto()
                {
                    Passport = x.Animal.Name,
                    OwnerNumber = x.Animal.Passport.OwnerPhoneNumber,
                    DateTime = x.DateAndTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    AnimalAids = x.ProcedureAnimalAids
                    .Select(p => new ExportAnimalAidsDto()
                    {
                        Name = p.AnimalAid.Name,
                        Price = p.AnimalAid.Price,
                    }).ToArray(),
                    TotalPrice = x.ProcedureAnimalAids.Select(aa => aa.AnimalAid.Price).Sum()

                })
                .OrderBy(y => y.DateTime)
                .ThenBy(y => y.Passport)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(typeof(ExportProceduresDto[]), new XmlRootAttribute("Procedures"));
            serializer.Serialize(new StringWriter(sb), procedures);

            return sb.ToString();
        }
    }
}
