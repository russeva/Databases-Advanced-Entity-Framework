namespace BettingSysDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        public int UderId { get; set; }
        public double Balance { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public ICollection<Bet> Bets { get; set; } = new HashSet<Bet>();
     }
}
