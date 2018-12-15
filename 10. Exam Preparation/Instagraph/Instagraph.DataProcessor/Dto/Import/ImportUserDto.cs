namespace Instagraph.DataProcessor.Dto.Import
{
    using System.Collections;
    using System.ComponentModel.DataAnnotations;

    public class ImportUserDto
    {
        [Required]
        public string Username{ get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ProfilePicture { get; set; }
    }
}
