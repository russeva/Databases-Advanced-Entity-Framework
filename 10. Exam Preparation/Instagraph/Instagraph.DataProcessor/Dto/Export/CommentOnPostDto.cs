namespace Instagraph.DataProcessor.Dto.Export
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("user")]
    public class CommentOnPostDto
    {
        public string Username { get; set; }

        public int MostComments { get; set; }
    }
}
