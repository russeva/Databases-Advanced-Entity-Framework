namespace Shop.App.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;


    [XmlType("category")]
    public class CategoryDto
    {
        
        [XmlElement("name")]
        [StringLength(12,MinimumLength = 3)]
        public string Name { get; set; }
    }
}
