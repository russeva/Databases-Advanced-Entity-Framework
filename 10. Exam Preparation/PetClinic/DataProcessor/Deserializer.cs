namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Microsoft.EntityFrameworkCore;

    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.ImportDto;
    using PetClinic.Models;

    public class Deserializer
    {

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var jsonDeserialized = JsonConvert.DeserializeObject<AnimalAidDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            List<AnimalAid> listAnimalAid = new List<AnimalAid>();

            foreach (var animalAidDto in jsonDeserialized)
            {
                if(!IsValid(animalAidDto))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                if(listAnimalAid.Any(x => x.Name == animalAidDto.Name))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }
                AnimalAid newAnimalAid = new AnimalAid()
                {
                    Name = animalAidDto.Name,
                    Price = Convert.ToDecimal(animalAidDto.Price)
                };

                listAnimalAid.Add(newAnimalAid);
                sb.AppendLine($"Record {animalAidDto.Name} successfully imported. ");
            }
            context.AnimalAids.AddRange(listAnimalAid);
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var jsonDeserialized = JsonConvert.DeserializeObject<ImportAnimalDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            List<Animal> listAnimal = new List<Animal>();

            foreach (var animalDto in jsonDeserialized)
            {
                if(!IsValid(animalDto) || !IsValid(animalDto.Passport))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                if(listAnimal.Any(x => x.Passport.SerialNumber == animalDto.PassportSerialNumber))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                Animal newAnimal = new Animal()
                {
                    Name = animalDto.Name,
                    Age = animalDto.Age,
                    Type = animalDto.Type,
                    Passport = new Passport()
                    {
                        OwnerName = animalDto.Passport.OwnerName,
                        OwnerPhoneNumber = animalDto.Passport.OwnerPhoneNumber,
                        SerialNumber = animalDto.Passport.SerialNumber,
                        RegistrationDate = DateTime.Parse(animalDto.Passport.RegistrationDate)
                    }      
                };
                listAnimal.Add(newAnimal);
                sb.AppendLine($"Record {animalDto.Name} Passport Number: {animalDto.Passport.SerialNumber} successfully imported.");
            }
            context.Animals.AddRange(listAnimal);
            context.SaveChanges();
            return sb.ToString();

        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var deserialized = new XmlSerializer(typeof(ImportVetDto[]), new XmlRootAttribute("Vets"));
            var deserializedVets = (ImportVetDto[])deserialized.Deserialize(new StringReader(xmlString));
            List<Vet> listVets = new List<Vet>();
            StringBuilder sb = new StringBuilder();

            foreach (var vetDto in deserializedVets)
            {
                if (!IsValid(vetDto))
                {
                    sb.AppendLine("Error message: Invalid data.");
                    continue;
                }

                if(listVets.Any(x => x.PhoneNumber == vetDto.PhoneNumber))
                {
                    sb.AppendLine("Error message: Invalid data.");
                    continue;
                }

                Vet newVet = new Vet()
                {
                    Name = vetDto.Name,
                    Age = vetDto.Age,
                    PhoneNumber = vetDto.PhoneNumber,
                    Proffesion = vetDto.Profession
                };

                listVets.Add(newVet);
                sb.AppendLine($"Record {vetDto.Name} successfully imported.");
            }
            context.Vets.AddRange(listVets);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var serialize = new XmlSerializer(typeof(ImportProcedureDto[]), new XmlRootAttribute("Procedures"));
            var procedure = (ImportProcedureDto[])serialize.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var validProcedures = new List<Procedure>();
            foreach (var procedureDto in procedure)
            {
                if(!IsValid(procedureDto))
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var vetExist = context.Vets.SingleOrDefault(x => x.Name == procedureDto.Vet);
                var animalExist = context.Animals.SingleOrDefault(x => x.PassportSerialNumber == procedureDto.Animal);
                var dateTime = DateTime.ParseExact(procedureDto.DateTime, "dd-MM-yyyy",CultureInfo.InvariantCulture);

                var aidInvalid = false;
                var proceduresAnimalAidsList = new List<ProcedureAnimalAid>();

                foreach (var aid in procedureDto.AnimalAids)
                {
                    var animalAid = context.AnimalAids.SingleOrDefault(a => a.Name == aid.Name);

                    if(animalAid == null || proceduresAnimalAidsList.Any(x => x.AnimalAid == animalAid))
                    {
                        aidInvalid = true;
                        break;
                    }

                    var procedureAnimalAid = new ProcedureAnimalAid
                    {
                        AnimalAid = animalAid
                    };

                    proceduresAnimalAidsList.Add(procedureAnimalAid);

                    if(vetExist == null || animalExist == null || aidInvalid)
                    {
                        sb.AppendLine("Error message: Invalid data.");
                        continue;
                    }

                    Procedure newProcedure = new Procedure()
                    {
                        Animal = animalExist,
                        Vet = vetExist,
                        ProcedureAnimalAids = proceduresAnimalAidsList,
                        DateAndTime = dateTime
                    };

                    validProcedures.Add(newProcedure);
                    sb.AppendLine("Record successfully imported.");
                }
              

            }
            context.Procedures.AddRange(validProcedures);
            context.SaveChanges();

            return sb.ToString();

        }

        public static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
