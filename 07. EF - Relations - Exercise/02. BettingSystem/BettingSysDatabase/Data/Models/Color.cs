namespace BettingSysDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Color
    {
        public int ColorId { get; set; }
        public string Name { get; set; }

        public ICollection<Team> PrimaryKitColorTeams { get; set; } = new HashSet<Team>();
        public ICollection<Team> SecondaryKitColorTeams { get; set; } = new HashSet<Team>();
    }
}
