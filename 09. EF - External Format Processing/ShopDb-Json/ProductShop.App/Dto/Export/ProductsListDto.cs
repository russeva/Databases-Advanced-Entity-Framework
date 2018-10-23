namespace ProductShop.App.Dto.Export
{
    using Newtonsoft.Json;
    public class ProductsListDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
