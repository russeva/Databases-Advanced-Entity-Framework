using System.Collections.Generic;

namespace BookShopSys.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }


        public ICollection<BookCategory> BookCategories { get; set; } = new HashSet<BookCategory>();
    }
}
