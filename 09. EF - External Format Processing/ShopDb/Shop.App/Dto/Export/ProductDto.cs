namespace Shop.App.Dto.Export
{
    
    using System.Xml.Serialization;

    [XmlType("product")]
    [XmlRoot("product")]
    public class ProductDto
    {
        public ProductDto()
        {
            
        }

        public ProductDto(string name,double price)
        {
            this.Name = name;
            this.Price = price;
        }
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public double Price { get; set; }
    }
}
