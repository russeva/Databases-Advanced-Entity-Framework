namespace CarDealer.Models
{
    public class PartCars
    {
        
        public int PartId { get; set; }

        public virtual Part Part { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
