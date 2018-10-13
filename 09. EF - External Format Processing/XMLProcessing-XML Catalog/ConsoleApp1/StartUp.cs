namespace XML.App
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using XML.Models;

    public class StartUp

    {
        public static void Main(string[] args)
        {
            XmlSerializer ser = new XmlSerializer(typeof(AlbumDto[]), new XmlRootAttribute("albums"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });


            AlbumDto[] albumLib = new AlbumDto []{
                new AlbumDto{
                    Id = 1,
                    Artist = "Kasabian",
                    Name = "Tomorrow never ends",
                    Price = 12.99,
                    Producer = "Dr. Seuss",
                    Year = 1997,
                    Songs = new List<SongDto>{
                        new SongDto {
                            Title = "Blue is my middle name",
                            Duration = 2.45
                        },
                         new SongDto {
                            Title = "Insomnia",
                            Duration = 3.09
                        },
                          new SongDto {
                            Title = "bla bla",
                            Duration = 4.06
                        }
                    }
                },
                new AlbumDto{
                    Id = 1,
                    Artist = "Paleotte",
                    Name = "Caaan Do",
                    Price = 12.99,
                    Producer = "Asteriks",
                    Year = 1997,
                    Songs = new List<SongDto>{
                        new SongDto {
                            Title = "Calm down",
                            Duration = 2.45
                        },
                         new SongDto {
                            Title = "Mooncake calling",
                            Duration = 3.09
                        },
                          new SongDto {
                            Title = "Chockli",
                            Duration = 4.06
                        }
                    }
                }
            };

            using (StreamWriter writer = new StreamWriter("../albums.xml"))
            {
                ser.Serialize(writer, albumLib, namespaces);
            }
        }
    }
}
