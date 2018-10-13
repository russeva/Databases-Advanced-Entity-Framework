namespace XML.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("album")]
    [XmlRoot("album")]
    public class AlbumDto
    {
        [XmlElement("id")]
        public int Id { get; set; }
        
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("artist")]
        public string Artist { get; set; }

        [XmlElement("year")]
        public int Year { get; set; }

        [XmlElement("producer")]
        public string Producer { get; set; }

        [XmlElement("price")]
        public double Price { get; set; }

        [XmlArrayItem(ElementName = "songs")]
        public List<SongDto> Songs { get; set; }
    }
}
