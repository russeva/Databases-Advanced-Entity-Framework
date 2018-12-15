namespace CarDealer.App.Import
{
    using System;
    using System.Xml.Serialization;

    [XmlType("part")]
    public class PartsImportDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public double Price { get; set; }

        [XmlAttribute("quantity")]
        public int Quantity { get; set; }
    }
}
