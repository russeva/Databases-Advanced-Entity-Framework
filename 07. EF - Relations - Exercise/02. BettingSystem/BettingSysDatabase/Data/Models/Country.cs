namespace BettingSysDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Country
    {
        public int CoutnryId { get; set; }
        public string Name{ get; set; }

        public ICollection<Town> Town { get; set; } = new HashSet<Town>();
    }
}
