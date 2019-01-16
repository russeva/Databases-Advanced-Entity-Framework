namespace VaporStore.Export.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("User")]
    public class UserPurchaseByType
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArrayItem("Purchases")]
        public ICollection<PurchaseDto> Purchases { get; set; }

        [XmlElement("TotalSpent")]
        public decimal TotalSpent { get; set; }
    }
}
