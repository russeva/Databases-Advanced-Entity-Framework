namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.ProductsSold = new List<Product>();
            this.ProductsBought = new List<Product>();
        }

        public User(string firstName, string lastName,int age)
            :this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [MinLengthAttribute(3)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public List<Product> ProductsSold { get; set; }

        public List<Product> ProductsBought { get; set; }
    }
}
