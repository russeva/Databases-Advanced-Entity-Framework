namespace PetClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Vet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3),MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MinLength(3),MaxLength(50)]
        public string Proffesion { get; set; }

        [Required]
        [Range(minimum: 22,maximum:65)]
        public int Age { get; set; }

        [RegularExpression(@"(^(\+359)\d{9}$)|(^0\d{9})$")]
        public string PhoneNumber { get; set; }

        public ICollection<Procedure> Procedures { get; set; } = new List<Procedure>();
    }
}
