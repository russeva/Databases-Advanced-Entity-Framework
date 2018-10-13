using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using XML.Models;

namespace XML.App
{
    class StartUp
    {
        public static void Main()
        {

            XmlSerializer ser = new XmlSerializer(typeof(StudentDto[]), new XmlRootAttribute("Books"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            StudentDto[] studentsLib = new StudentDto[2] {
                new StudentDto  {
                    Id = 1,
                    Name = "Timur",
                    Email = "racoon@forest.gump",
                    FacultyNumber = "4583202035",
                    Gender = "Male",
                    PhoneNumber = "075934444",
                    University = "SoftUni",
                    Speciality = "Java Development",
                    Exams = new ExamDto[]{
                        new ExamDto {
                            Name = "Java Web Development",
                            DateTaken = DateTime.ParseExact("2018/07/14","yyyy/MM/dd",CultureInfo.InvariantCulture),
                            Grade = 5
                        },
                        new ExamDto {
                            Name = "Java DB Development",
                            DateTaken = DateTime.ParseExact("2018/05/31","yyyy/MM/dd",CultureInfo.InvariantCulture),
                            Grade = 6
                        },

                    },
                },
                new StudentDto  {
                    Id = 1,
                    Name = "Daisy",
                    Email = "blablah@dracula.ro",
                    FacultyNumber = "670038434",
                    Gender = "Gender",
                    PhoneNumber = "0347756",
                    University = "SoftUni",
                    Speciality = "C# Development",
                    Exams = new ExamDto[]{
                        new ExamDto {
                            Name = "C# Web Development",
                            DateTaken = DateTime.ParseExact("2018/07/14","yyyy/MM/dd",CultureInfo.InvariantCulture),
                            Grade = 5
                        },
                        new ExamDto {
                            Name = "C# D" +
                            "B Development",
                            DateTaken = DateTime.ParseExact("2018/05/31","yyyy/MM/dd",CultureInfo.InvariantCulture),
                            Grade = 6
                        }


                    }

                }

        };

            using (TextWriter writer = new StreamWriter("../Students.xml"))
            {
                ser.Serialize(writer, studentsLib, namespaces);
            }
        }
    }
}
