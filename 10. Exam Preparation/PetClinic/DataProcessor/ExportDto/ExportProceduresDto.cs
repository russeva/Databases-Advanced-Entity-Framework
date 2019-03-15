namespace PetClinic.DataProcessor.ExportDto
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ExportProceduresDto
    {
        
        public string Passport { get; set; }

        
        public string OwnerNumber { get; set; }

        
        public string DateTime { get; set; }

        [XmlArrayItem("AnimalAids")]
        public ExportAnimalAidsDto[] AnimalAids { get; set; }

        
        public decimal TotalPrice { get; set; }
    }
}
