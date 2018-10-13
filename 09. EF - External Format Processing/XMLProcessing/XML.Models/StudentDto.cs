namespace XML.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "student")]
    [XmlType("student")]
    public class StudentDto
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("gender")]
        public string Gender { get; set; }

        [XmlElement("phoneNumber")]
        public string PhoneNumber { get; set; }

        [XmlElement("email")]
        public string Email { get; set; }

        [XmlElement("university")]
        public string University { get; set; }

        [XmlElement("speciality")]
        public string Speciality { get; set; }

        [XmlElement("facultyNumber")]
        public string FacultyNumber { get; set; }

        [XmlArrayItem(ElementName = "exams")]
        public ExamDto[] Exams { get; set; } 
        

    }
}
