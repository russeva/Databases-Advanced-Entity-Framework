namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CategoryProducts
    {
        public CategoryProducts()
        {

        }

        public CategoryProducts(int categoryId, int productId)
        {
            this.CategoryId = categoryId;
            this.ProductId = productId;

        }
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

    }
}
