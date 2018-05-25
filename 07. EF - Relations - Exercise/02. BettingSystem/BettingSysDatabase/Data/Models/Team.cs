using System.Collections.Generic;

namespace BettingSysDatabase.Data.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public double Budget { get; set; }
        public string Initials { get; set; }
        public string LogoUrl { get; set; }
        public string Name { get; set; }

        public int PrimaryKitColorId{ get; set; }
        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }
        public Town Town{ get; set; }

        public ICollection<Game> AwayGames { get; set; } = new HashSet<Game>();
        public ICollection<Game> HomeGames { get; set; } = new HashSet<Game>();
        public ICollection<Player> Player { get; set; } = new HashSet<Player>();
    }
}
