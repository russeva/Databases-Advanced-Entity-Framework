using System;
using System.IO;

using AutoMapper;

using Instagraph.Data;
using Instagraph.DataProcessor;
using System.Text;

namespace Instagraph.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<InstagraphProfile>();
            });

            IMapper mapper = config.CreateMapper();


            Console.WriteLine(ResetDatabase());

            Console.WriteLine(ImportData(mapper));

            ExportData();
        }

        private static string ImportData(IMapper mapper)
        {
            StringBuilder sb = new StringBuilder();

            using (var context = new Data.InstagraphProfile())
            {
                string picturesJson = File.ReadAllText("../../../files/input/pictures.json");

                sb.AppendLine(Deserializer.ImportPictures(context, picturesJson, mapper));

                string usersJson = File.ReadAllText("../../../files/input/users.json");

                sb.AppendLine(Deserializer.ImportUsers(context, usersJson, mapper));

                string followersJson = File.ReadAllText("../../../files/input/users_followers.json");

                sb.AppendLine(Deserializer.ImportFollowers(context, followersJson, mapper));

                string postsXml = File.ReadAllText("../../../files/input/posts.xml");

                sb.AppendLine(Deserializer.ImportPosts(context, postsXml));

                string commentsXml = File.ReadAllText("../../../files/input/comments.xml");

                sb.AppendLine(Deserializer.ImportComments(context, commentsXml));
            }

            string result = sb.ToString().Trim();
            return result;
        }

        private static void ExportData()
        {
            using (var context = new Data.InstagraphProfile())
            {
                string uncommentedPostsOutput = Serializer.ExportUncommentedPosts(context);

                File.WriteAllText("../../../files/output/UncommentedPosts.json", uncommentedPostsOutput);

                string usersOutput = Serializer.ExportPopularUsers(context);

                File.WriteAllText("../../../files/output/PopularUsers.json", usersOutput);

                string commentsOutput = Serializer.ExportCommentsOnPosts(context);

                File.WriteAllText("../../../files/output/CommentsOnPosts.xml", commentsOutput);
            }
        }
        
        private static string ResetDatabase()
        {
            using (var context = new Data.InstagraphProfile())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return $"Database reset succsessfully.";
        }
    }
}
