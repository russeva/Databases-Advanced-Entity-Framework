namespace Shop.App.Dto.Import
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("product")]
    public class ProductsRangeDto
    {
        public ProductsRangeDto()
        {

        }



        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public double Price { get; set; }

        [XmlAttribute("buyer")]
        public string Buyer { get; set; }
    }
}
