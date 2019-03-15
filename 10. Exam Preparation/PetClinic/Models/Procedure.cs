namespace PetClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Procedure
    {
        [Key]
        public int Id { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public int VetId { get; set; }
        [Required]
        public Vet Vet { get; set; }

        public ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; } = new List<ProcedureAnimalAid>();

        [NotMapped]
        public decimal Cost { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }
    }
}
