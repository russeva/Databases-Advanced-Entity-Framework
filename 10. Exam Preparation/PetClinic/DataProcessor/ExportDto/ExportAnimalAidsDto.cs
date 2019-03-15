namespace PetClinic.DataProcessor.ExportDto
{
    using System;
    using System.Xml.Serialization;

    [XmlType("AnimalAid")]
    public class ExportAnimalAidsDto
    {
        
        public string Name { get; set; }

        
        public decimal Price { get; set; }
    }
}
