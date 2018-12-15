namespace Instagraph.DataProcessor.Dto.Export
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PopularUsersDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public int Followers { get; set; }
    }
}
