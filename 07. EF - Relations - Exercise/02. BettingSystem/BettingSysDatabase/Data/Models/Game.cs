namespace BettingSysDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        public int GameId { get; set; }
        public double AwayTeamBetRate { get; set; }
        public double AwayTeamGoals { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public double DrawBetRate { get; set; }
        public double HomeTeamBetRate { get; set; }
        public double HomeTeamGoals { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public double Result { get; set; }
        public DateTime DateTime { get; set; }

        public ICollection<Bet> Bets { get; set; } = new HashSet<Bet>();
        public ICollection<PlayerStatistics> PlayerStatistics { get; set; } = new HashSet<PlayerStatistics>();

    }
}
