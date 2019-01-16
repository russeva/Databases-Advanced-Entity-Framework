namespace VaporStore.Export.Dto
{
    using System;
    using System.Collections.Generic;
    
    public class ExportGameDto
    {
        public int Id { get; set; }

        public string Genre { get; set; }

        public List<ExportGamesByGenres> Games { get; set; }
    }
}
