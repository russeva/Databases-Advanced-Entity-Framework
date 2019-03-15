using System;

namespace PetClinic.DataProcessor.ExportDto
{
    public class ExportAnimalsByOwner
    {
       
        public string OwnerName { get; set; }

        public string AnimalName { get; set; }

        public int Age { get; set; }

        public string SerialNumber { get; set; }

        public string RegisteredOn { get; set; }
    }
}
