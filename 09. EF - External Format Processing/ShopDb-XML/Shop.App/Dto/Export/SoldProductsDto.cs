namespace Shop.App.Dto.Export
{
    using Shop.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("user")]
    public class SoldProductsDto
    {
        public SoldProductsDto()
        {
            
        }

        public SoldProductsDto(string firstName, string lastName)
            :this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlArray("sold-products")]
        public ProductDto[] SoldProducts { get; set; }



    }
}
