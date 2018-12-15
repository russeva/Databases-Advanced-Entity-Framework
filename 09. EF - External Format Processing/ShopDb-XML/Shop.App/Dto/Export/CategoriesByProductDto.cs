namespace Shop.App.Dto.Export
{
    
    using System.Xml.Serialization;

    [XmlType("category")]
    public class CategoriesByProductDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("product-count")]
        public int ProductCount { get; set; }

        [XmlElement("average-price")]
        public double AveragePrice { get; set; }

        [XmlElement("total-revenue")]
        public double TotalRevenue { get; set; }



    }
}
