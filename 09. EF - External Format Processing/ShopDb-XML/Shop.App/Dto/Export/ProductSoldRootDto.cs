namespace Shop.App.Dto.Export
{
    
    using System.Xml.Serialization;

    [XmlType("sold-products")]
    public class ProductSoldRootDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("product")]
        public ProductsSoldDto[] ProductSoldDtos { get; set; }
    }
}
