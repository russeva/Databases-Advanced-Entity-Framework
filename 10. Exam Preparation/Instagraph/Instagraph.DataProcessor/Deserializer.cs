namespace Instagraph.DataProcessor
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using AutoMapper;
    
    using Microsoft.EntityFrameworkCore;

    using Instagraph.Data;
    
    using Instagraph.Models;
    using System.ComponentModel.DataAnnotations;
    using Instagraph.DataProcessor.Dto.Import;
    using System.IO;
    using System.Xml.Serialization;


    public class Deserializer
    {
       private const string errorMessage = "Error: Invalid data.";

        public static string ImportPictures(InstagraphProfile context, string jsonString, IMapper mapper)
        {
            var picturesString = JsonConvert.DeserializeObject<ImportPicsDto[]>(jsonString);
            List<Picture> pictureList = new List<Picture>();
            StringBuilder sb = new StringBuilder();

            foreach (ImportPicsDto picDto in picturesString)
            {
                if((picDto.Path == null) || (picDto.Size <= 0))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                if(pictureList.Any(x => x.Path == picDto.Path))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                Picture picture = mapper.Map<Picture>(picDto);
                pictureList.Add(picture);
                sb.AppendLine($"Successfully imported Picture {picDto.Path}.");


            }
            context.Pictures.AddRange(pictureList);
            context.SaveChanges();


            string result = sb.ToString();
            return result;
        }

        public static string ImportUsers(InstagraphProfile context, string jsonString, IMapper mapper)
        {
            var userString = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);
            List<User> userList = new List<User>();
            StringBuilder sb = new StringBuilder();

            foreach(ImportUserDto userDto in userString)
            {
                if(!IsValid(userDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                User currentUser = new User() {
                    Username = userDto.Username,
                    ProfilePicture = new Picture() { Path = userDto.ProfilePicture },
                    Password = userDto.Password
                };

                userList.Add(currentUser);
                sb.AppendLine($"Successfully imported User {userDto.Username}.");
            }

            context.Users.AddRange(userList);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportFollowers(InstagraphProfile context, string jsonString, IMapper mapper)
        {
            var followersString = JsonConvert.DeserializeObject<ImportFollowersDto[]>(jsonString);
            List<UserFollower> followersList = new List<UserFollower>();
            StringBuilder sb = new StringBuilder();


            foreach (ImportFollowersDto followerDto in followersString)
            {
                if(!IsValid(followerDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;

                }

                var userExist = context.Users.Any(x => x.Username == followerDto.User);
                var followerExist = context.Users.Any(x => x.Username == followerDto.Follower);
                

                if(!userExist || !followerExist)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                

                int? followerId = context.Users
                    .FirstOrDefault(x => x.Username == followerDto.Follower)?.Id;

                int? userId = context.Users
                    .FirstOrDefault(x => x.Username == followerDto.User)?.Id;

                bool alreadyFollowed = followersList.Any(f => f.UserId == userId && f.FollowerId == followerId);
                if (alreadyFollowed)
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }


                var newEntity = new UserFollower() {
                    FollowerId = followerId.Value,
                    UserId = userId.Value
                };

                followersList.Add(newEntity);
                sb.AppendLine($"Successfully imported Follower {followerDto.Follower} to User {followerDto.User}.");



            }

            context.UserFollowers.AddRange(followersList);
            context.SaveChanges();

            string result = sb.ToString();
            return result;
        }

        public static string ImportPosts(InstagraphProfile context, string xmlString)
        {
           XmlSerializer serializer = new XmlSerializer(typeof(ImportPostsDto[]), new XmlRootAttribute("posts"));
            ImportPostsDto[] deserializedCategories = (ImportPostsDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Post> listPosts = new List<Post>();
            StringBuilder sb = new StringBuilder();

            foreach (ImportPostsDto postsDto in deserializedCategories)
            {
                if (!IsValid(postsDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                var pictureExist = context.Pictures.FirstOrDefault(p => p.Path == postsDto.Picture);
                var userExist = context.Users.FirstOrDefault(u => u.Username == postsDto.User);

                if ((pictureExist == null) || (userExist == null))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }
                

                Post post = new Post() {
                    UserId = userExist.Id,
                    PictureId = pictureExist.Id,
                    Caption = postsDto.Caption
                };

                listPosts.Add(post);
                sb.AppendLine($"Successfully imported Post {postsDto.Caption}.");
                

            }

            context.Posts.AddRange(listPosts);
            context.SaveChanges();
            string result = sb.ToString();
            return result;

        }

        public static string ImportComments(InstagraphProfile context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCommentDto[]), new XmlRootAttribute("comments"));
            ImportCommentDto[] deserializedComments = (ImportCommentDto[])serializer.Deserialize(new StringReader(xmlString));
            List<Comment> listComments = new List<Comment>();
            StringBuilder sb = new StringBuilder();

            foreach (ImportCommentDto commentDto in deserializedComments)
            {
              if(!IsValid(commentDto))
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                int? userId = context.Users.SingleOrDefault(u => u.Username == commentDto.User)?.Id;
                bool postExist = context.Posts.Any(p => p.Id == commentDto.PostId.Id);
               
                if(userId == null || !postExist )
                {
                    sb.AppendLine(errorMessage);
                    continue;
                }

                Comment comment = new Comment() {
                    UserId = userId.Value,
                    PostId = commentDto.PostId.Id,
                    Content = commentDto.Content
                };

                listComments.Add(comment);
                sb.AppendLine($"Successfully imported Comment {commentDto.Content}.");
            }
            context.Comments.AddRange(listComments);
            context.SaveChanges();

            return sb.ToString();
        }

        public static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
        }
    }
}
