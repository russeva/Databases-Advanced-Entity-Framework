 namespace DatabaseInitializer.Generators
{
    using System;
    using StudentDatabase.Data.Models;

    public static class ResourceGenerator
    {
        private static string[] nameList = {
            "Tutorial's Points",
            "DotNetPearlss",
            "CodeAcademia",
            "SoftUni"
        };

        private static string[] urlList = {
            "https://www.demo.url",
            "https://www.randomly.gen",
            "http://www.blabla.com",
            "http://www.demo.gen"
        };

        public static Resource GenerateResource()
        {
            Resource newResource = new Resource() {
                 Name = GenerateName(),
                 Url = GenerateUrl(),
            };

            return newResource;
        }

        private static string GenerateName()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, nameList.Length);
            string currentName = nameList[index];

            return currentName;
        }

        private static string GenerateUrl()
        {
            Random rnd = new Random();
            int index = rnd.Next(0, urlList.Length);
            string currentUrl = urlList[index];

            return currentUrl;
        }
    }
}
