namespace XML.Models
{
    using System;
    using System.Xml.Serialization;

    [XmlType("exam")]
    public class ExamDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("dateTaken")]
        public DateTime DateTaken { get; set; }

        [XmlElement("grade")]
        public decimal Grade { get; set; }
    }
}
