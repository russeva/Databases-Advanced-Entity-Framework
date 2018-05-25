namespace BettingSysDatabase.Data.Models
{
    using System;

    public class PlayerStatistics
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public string Assists { get; set; }
        public double MinutesPlayed { get; set; }
        public int ScoredGoals { get; set; }
    }
}
