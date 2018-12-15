namespace Instagraph.DataProcessor.Dto.Import
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("comment")]
    public class ImportCommentDto
    {
        [XmlElement("content")]
        public string Content { get; set; }

        [XmlElement("user")]
        public string User { get; set; }

        [XmlElement("post")]
        [Required]
        public PostDto PostId { get; set; }

    }
}
