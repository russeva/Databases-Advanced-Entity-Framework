namespace CarDealer.Models
{
    using System.Collections.Generic;

    public class Supplier
    {
        public Supplier()
        {
            this.Parts = new List<Part>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsImporter { get; set; }

        public virtual List<Part> Parts { get; set; }
    }
}
