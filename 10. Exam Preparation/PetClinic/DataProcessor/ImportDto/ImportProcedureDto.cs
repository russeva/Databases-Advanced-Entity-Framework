namespace PetClinic.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ImportProcedureDto
    {
        [Required]
        [XmlElement]
        public string Vet { get; set; }

        [XmlElement]
        public string Animal { get; set; }

        [Required]
        [XmlElement]
        public string DateTime { get; set; }

        [XmlArray]
        public ImportSimpleAnimalAid[] AnimalAids { get; set; } 
    }
}
