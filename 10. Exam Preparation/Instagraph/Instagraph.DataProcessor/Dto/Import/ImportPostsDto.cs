namespace Instagraph.DataProcessor.Dto.Import
{
    using Instagraph.Models;
    using System.Xml.Serialization;

    [XmlType("post")]
    public class ImportPostsDto
    {
        [XmlElement("caption")]
        public string Caption { get; set; }

        [XmlElement("user")]
        public string User { get; set; }

        [XmlElement("picture")]
        public string Picture { get; set; }
    }
}
