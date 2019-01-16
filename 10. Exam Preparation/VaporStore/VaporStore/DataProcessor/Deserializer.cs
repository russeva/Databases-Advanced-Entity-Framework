namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enum;
    using VaporStore.Import.Dto;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            var jsonDeserialized = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            StringBuilder sb = new StringBuilder();

            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<string> dbTags = new List<string>();

            foreach (ImportGameDto gameDto in jsonDeserialized)
            {
                if(!IsValid(gameDto) || !IsValid(gameDto.Tags))
                {
                    sb.AppendLine("Invalid data");
                    continue;
                }

                var developer = developers.FirstOrDefault(x => x.Name == gameDto.Developer);
                if (developer == null)
                {
                    developer = new Developer() { Name = gameDto.Developer};
                    developers.Add(developer);
                }

                var genre = genres.FirstOrDefault(x => x.Name == gameDto.Genre);
                if(genre == null)
                {
                    genre = new Genre() { Name = gameDto.Genre };
                    genres.Add(genre);
                }

                List<Tag> gameTag = new List<Tag>();
                foreach (string tag in gameDto.Tags)
                {
                    if(!dbTags.Contains(tag))
                    {
                        dbTags.Add(tag);
                    }
                    gameTag.Add(new Tag() { Name = tag});
                }

                Game newGame = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate,
                    Developer = developer,
                    Genre = genre,
                    GameTags = gameTag.Select(x => new GameTag() { Tag = x }).ToList()
                
                };
                context.Games.Add(newGame);
                sb.AppendLine($"Added {gameDto.Name} ({gameDto.Genre}) with {gameDto.Tags.Count()} tags");
            }
            Console.WriteLine();
            context.SaveChanges();
            var result = sb.ToString();
            return result;
            
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            var jsonDeserialized = JsonConvert.DeserializeObject<ImportUsersDto[]>(jsonString, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            StringBuilder sb = new StringBuilder();

            foreach (ImportUsersDto usersDto in jsonDeserialized)
            {
                if(!IsValid(usersDto) || !IsValid(usersDto.Cards))
                {
                    sb.AppendLine("Invalid data.");
                    continue;
                }

               
                User newUser = new User()
                {
                    FullName = usersDto.FullName,
                    Username = usersDto.Username,
                    Email = usersDto.Email,
                    Age = usersDto.Age,
                    Cards = usersDto.Cards.Select(x => new Card()
                    {
                        Name = x.Number,
                        Cvc = x.Cvc,
                        Type = x.Type
                    }).ToList()
                   
                };
                context.Users.Add(newUser);

                sb.AppendLine($"Imported {usersDto.Username} with {usersDto.Cards.Count()} cards");
            }
            Console.WriteLine();
            context.SaveChanges();
            string result;

            return result = sb.ToString();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            var xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));
            var deserialized = (ImportPurchaseDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();

            List<Game> games = context.Games.Select(x => x).ToList();
            List<Card> cards = context.Cards.Select(x => x).ToList();
            List<Purchase> purchases = new List<Purchase>();

            foreach (ImportPurchaseDto purchaseDto in deserialized)
            {
                if(!IsValid(purchaseDto))
                {
                    sb.AppendLine("Invalid data");
                    continue;
                }

                DateTime date;
                var datastring = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture,DateTimeStyles.None,out date);

                var card = cards.FirstOrDefault(x => x.Name == purchaseDto.Card);
                var game = games.FirstOrDefault(x => x.Name == purchaseDto.Title);
                var type = Enum.Parse<PurchaseType>(purchaseDto.Type);

                if(card == null || game == null)
                {
                    sb.AppendLine("Invalid data");
                    continue;
                }
                Purchase newPucrhase = new Purchase()
                {
                    ProductKey = purchaseDto.Key,
                    Date = date,
                    Card = card,
                    Game = game,
                    Type = type
                };

                purchases.Add(newPucrhase);
                sb.AppendLine($"Imported {purchaseDto.Title} for {card.User.Username}");
            }
            
            context.Purchases.AddRange(purchases);
            context.SaveChanges();
            var result = sb.ToString();
            return result;
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