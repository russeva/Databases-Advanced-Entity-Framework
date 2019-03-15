namespace PetClinic.DataProcessor.ImportDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ImportAnimalDto
    {
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Age { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Type { get; set; }

        public string PassportSerialNumber { get; set; }
        [Required]
        public ImportPassportDto Passport { get; set; }

    }
}
