namespace CarDealer.Models
{
    using System;
    using System.Collections.Generic;

    public class Car
    {
        public Car()
        {
            this.Sales = new List<Sale>();
            this.Parts = new List<PartCars>();
        }
       

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public double TravelledDistance { get; set; }

        public virtual List<Sale> Sales { get; set; }

        public virtual List<PartCars> Parts { get; set; } 
    }
}
