﻿using System.Collections.Generic;

namespace BookShopSys.Data.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
