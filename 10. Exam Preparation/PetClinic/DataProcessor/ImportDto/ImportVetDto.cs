namespace PetClinic.DataProcessor.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Vet")]
    public class ImportVetDto
    {
        [XmlElement]
        [MinLength(3), MaxLength(40)]
        public string Name { get; set; }

        [XmlElement]
        [Required]
        [MinLength(3), MaxLength(50)]
        public string Profession { get; set; }

        [XmlElement]
        [Required]
        [Range(minimum: 22, maximum: 65)]
        public int Age { get; set; }

        [XmlElement]
        [RegularExpression(@"(^(\+359)\d{9}$)|(^0\d{9})$")]
        public string PhoneNumber { get; set; }
    }
}
