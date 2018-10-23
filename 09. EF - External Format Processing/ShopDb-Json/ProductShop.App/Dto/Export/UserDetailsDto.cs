namespace ProductShop.App.Dto.Export
{
    using Newtonsoft.Json;
    public class UserDetailsDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        public SoldProductsByUserDto[] SoldProducts { get; set; }
    }
}
