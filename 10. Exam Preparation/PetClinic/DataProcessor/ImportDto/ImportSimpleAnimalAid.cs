using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.ImportDto
{
    [XmlType("AnimalAid")]
    public class ImportSimpleAnimalAid
    {
        [XmlElement]
        [Required]
        [MinLength(3), MaxLength(40)]
        public string Name { get; set; }
    }
}
