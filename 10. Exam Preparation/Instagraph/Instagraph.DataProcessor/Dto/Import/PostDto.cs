namespace Instagraph.DataProcessor.Dto.Import
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("post")]
    public class PostDto
    {
        [Required]
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
