namespace ProductShop.App.Dto.Export
{
    using Newtonsoft.Json;
    using System;

    public class UserRootDto
    {
        [JsonProperty("userCount")]
        public int UserCount { get; set; }

       
        public  UserDetailsDto[] UserDetails { get; set; }
    }
}
