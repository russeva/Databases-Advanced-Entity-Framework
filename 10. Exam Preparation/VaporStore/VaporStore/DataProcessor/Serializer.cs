namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enum;
    using VaporStore.Export.Dto;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            List<ExportGameDto> exportGames = new List<ExportGameDto>();

            foreach (var genre in genreNames)
            {
                var allGamesGenre = context.Games
                    .Where(x => x.Genre.Name == genre)
                    .Select(x => x)
                    .ToList();

                var allGamesPurchase = allGamesGenre
                    .Where(g => g.Purchases != null)
                    .Select(gg => gg).ToList();

                var games = allGamesPurchase.Select(y => new ExportGamesByGenres()
                {
                    Id = y.Id,
                    Title = y.Name,
                    Developer = y.Developer.Name,
                    Tags =  y.GameTags.Select(s => s.Tag.Name).ToList(),
                    Players = y.Purchases.Count(),
                })
                .OrderByDescending(x => x.Players)
                .ThenBy(x => x.Id)
                .ToList();

                ExportGameDto exportGame = new ExportGameDto()
                {
                    Id = context.Genre.Single(x => x.Name == genre).Id,
                    Genre = genre,
                    Games = games

                };
                exportGames.Add(exportGame);
            }
            exportGames = exportGames
                 .OrderByDescending(x => x.Games.Sum(g => g.Players))
                 .ThenBy(x => x.Id).ToList();

            var result = JsonConvert.SerializeObject(exportGames, Formatting.Indented);
            return result;
        }


        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
          


            throw new NotImplementedException();
        }
    }
}

