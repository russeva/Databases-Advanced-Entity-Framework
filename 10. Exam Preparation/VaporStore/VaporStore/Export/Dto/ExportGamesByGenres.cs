namespace VaporStore.Export.Dto
{
    using System.Collections.Generic;

    public class ExportGamesByGenres
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Developer { get; set; }

        public ICollection<string> Tags { get; set; }

        public int Players { get; set; }
    }
}
