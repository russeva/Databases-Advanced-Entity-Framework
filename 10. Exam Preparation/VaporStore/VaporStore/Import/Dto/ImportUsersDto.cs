namespace VaporStore.Import.Dto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ImportUsersDto
    {
        [Required]
        [RegularExpression("^[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+$")]
        public string FullName { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Range(3, 103)]
        public int Age { get; set; }

        public ICollection<ImportCardDto> Cards { get; set; }
    }
}
