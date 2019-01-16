namespace VaporStore.Export.Dto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    public class PurchaseDto
    {
        [Required]
        [XmlElement("Card")]
        [RegularExpression(@"^\d{4} \d{4} \d{4} \d{4}$")]
        public string Card { get; set; }

        [Required]
        [XmlElement("Cvc")]
        [RegularExpression(@"^\d{3}$")]
        public string Cvc { get; set; }

        public string Date { get; set; }

        [XmlArray("Game")]
        public GameDto Game { get; set; }

       
    }
}
