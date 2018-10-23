namespace ProductShop.App.Dto.Export
{
    using Newtonsoft.Json;

    public class CategoriesByProductDto
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("productsCount")]
        public int ProductsCount{ get; set; }

        [JsonProperty("averagePrice")]
        public decimal AveragePrice { get; set; }

        [JsonProperty("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}
