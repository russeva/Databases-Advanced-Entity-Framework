namespace BettingSysDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Player
    {
        public int PlayerId { get; set; }
        public bool IsInjured { get; set; }
        public string Name { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public int SquadNumber { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public ICollection<PlayerStatistics> PlayerStatistics { get; set; } = new HashSet<PlayerStatistics>();
     }
}
