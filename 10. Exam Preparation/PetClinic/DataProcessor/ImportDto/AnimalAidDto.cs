using System.ComponentModel.DataAnnotations;

namespace PetClinic.DataProcessor.ImportDto
{
    public class AnimalAidDto
    {
        [Required]
        [MinLength(3), MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public string Price { get; set; }
    }
}
