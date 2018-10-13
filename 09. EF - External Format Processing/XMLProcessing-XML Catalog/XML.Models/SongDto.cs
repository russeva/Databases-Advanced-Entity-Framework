using System.Xml.Serialization;

namespace XML.Models
{
    [XmlType("song")]
    public class SongDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("duration")]
        public double Duration { get; set; }
    }
}
