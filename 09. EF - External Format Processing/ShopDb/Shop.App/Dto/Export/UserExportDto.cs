namespace Shop.App.Dto.Export
{
    using System.Xml.Serialization;

    [XmlRoot("users")]
    public class UserExportDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("user")]
        public UsersAndProductsDto[] Users { get; set; }
    }
}
