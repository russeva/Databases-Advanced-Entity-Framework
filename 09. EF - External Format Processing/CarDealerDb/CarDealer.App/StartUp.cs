namespace CarDealer.App
{
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using AutoMapper;
    using CarDealer.App.Import;
    using CarDealer.Data;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    class StartUp
    {
        static void Main(string[] args)
        {

            CarDealerDbContext db = new CarDealerDbContext();
            db.Database.EnsureCreated();

            var mappingConfig = new MapperConfiguration(cnfg =>{
                cnfg.AddProfile(new CarDealerProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            using (db)
            {
               // ImportSuppliers(db,mapper);
                 // ImportParts(db, mapper);
                //ImportCars(db, mapper);
             ImportPartsCars(db, mapper);
            }

        }

        private static void ImportPartsCars(CarDealerDbContext db, IMapper mapper)
        {
            int countCars = db.Cars.Count();

            List<PartCars> listParts = new List<PartCars>();
            for (int i = 0; i < countCars; i++)
            {
                PartCars partCar = new PartCars();
                partCar.CarId = i;
                partCar.PartId = new Random().Next(1, 132);

                listParts.Add(partCar);
            }
            
            db.PartCars.AddRange(listParts);
            db.SaveChanges();
        }

        private static void ImportCars(CarDealerDbContext db, IMapper mapper)
        {
            String xmlString = File.ReadAllText("cars.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCarsDto[]),new XmlRootAttribute("cars"));
            ImportCarsDto[] deserializedParts = (ImportCarsDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Car> listCars = new List<Car>();

            foreach (ImportCarsDto carsDto in deserializedParts)
            {
                if (!IsValid(carsDto))
                {
                    continue;
                }

                Car car = mapper.Map<Car>(carsDto);
                listCars.Add(car);
            }
            db.Cars.AddRange(listCars);
            db.SaveChanges();

            
        }

        private static void ImportParts(CarDealerDbContext db, IMapper mapper)
        {
            String xmlString = File.ReadAllText("parts.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(PartsImportDto[]), new XmlRootAttribute("parts"));
            PartsImportDto[] deserializedParts = (PartsImportDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Part> listParts = new List<Part>();

            foreach (PartsImportDto partDto in deserializedParts)
            {
                if(!IsValid(partDto))
                {
                    continue;
                }

                Part part = mapper.Map<Part>(partDto);

                var randomSupplier = new Random().Next(1,32);
                part.SupplierId = randomSupplier;
                listParts.Add(part);
            }
            db.Parts.AddRange(listParts);
            db.SaveChanges();
            Console.WriteLine();
        }

        public static void ImportSuppliers(CarDealerDbContext context, IMapper mapper)
        {
            String xmlString = File.ReadAllText("suppliers.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(SupplierImportDto[]), new XmlRootAttribute("suppliers"));
            SupplierImportDto[] deserializedCategories = (SupplierImportDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Supplier> suppliersList = new List<Supplier>();

            foreach (SupplierImportDto entry in deserializedCategories)
            {
                if(!IsValid(entry))
                {
                    continue;
                }

                Supplier supplier = mapper.Map<Supplier>(entry);
                suppliersList.Add(supplier);
            }

            context.Supplier.AddRange(suppliersList);
            context.SaveChanges();
            Console.WriteLine();
        }

        public static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
