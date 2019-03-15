namespace PetClinic.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Type { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int Age { get; set; }

        public string PassportSerialNumber { get; set; }
        [Required]
        public Passport Passport { get; set; }

        public ICollection<Procedure> Procedures { get; set; } = new List<Procedure>();

    }
}
