namespace Instagraph.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Instagraph.Data;
    using Instagraph.DataProcessor.Dto.Export;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphProfile context)
        {
            var posts = context.Posts
                .Where(p => p.Comments.Count == 0)
                .Select(x => new UncommentedPostsDto() {
                    Id = x.Id,
                    Picture = x.Picture.Path,
                    User = x.User.Username
                })
                .OrderBy(o => o.Id)
                .ToArray();

            string jsonString = JsonConvert.SerializeObject(posts, Formatting.Indented);
            return jsonString;
        }

        public static string ExportPopularUsers(InstagraphProfile context)
        {
            var usersCollection = context.Users
                .Include(x => x.Posts)
                .Include(x => x.Comments)
                .Include(x => x.UserFollowers)
                .ToArray();

            var users = usersCollection.Select(x =>
            new PopularUsersDto() {
                Id = x.Id,
                Username = x.Username,
                Followers = x.UserFollowers.Count()
            })
            .OrderBy(x => x.Id)
            .ToArray();

            string jsonString = JsonConvert.SerializeObject(users, Formatting.Indented);
            return jsonString;
        }

        public static string ExportCommentsOnPosts(InstagraphProfile context)
        {
            var users = context.Users
                  .Include(x => x.Posts)
                  .Include(x => x.Comments)
                  .ToArray();

            var topPosts = users.Select(x => new CommentOnPostDto {
                Username = x.Username,
                MostComments = x.Posts.Max(p => (int?)p.Comments.Count) ?? 0
            })
            .OrderByDescending(u => u.MostComments)
            .ThenBy(u => u.Username)
            .ToArray();

            StringBuilder sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(CommentOnPostDto[]), new XmlRootAttribute("users"));
            serializer.Serialize(new StringWriter(sb), topPosts, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            string result = sb.ToString();
            return result;
        }
    }
}
