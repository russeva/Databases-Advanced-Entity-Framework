namespace Shop.Models
{
    using System;
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.Products = new List<CategoryProducts>();
        }

        public Category(string name)
            :this()
        {
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<CategoryProducts> Products{ get; set; }
    }
}
