namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Product
    {
        public Product()
        {
            this.Categories = new List<CategoryProducts>();
        }

        public Product(string name, double price, int sellerId, int? buyerId)
            :this()
        {

        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int? BuyerId { get; set; }

        [NotMapped]
        public User Buyer { get; set; }

        public int SellerId { get; set; }

        [NotMapped]
        public User Seller { get; set; }

        public List<CategoryProducts> Categories { get; set; }
    }
}
