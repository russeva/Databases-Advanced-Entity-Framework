namespace ProductShop.App.Dto.Export
{
    using Newtonsoft.Json;

    public class SoldProductsByUserDto
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        public ProductsListDto[] ProductsList { get; set; }
    }
}
