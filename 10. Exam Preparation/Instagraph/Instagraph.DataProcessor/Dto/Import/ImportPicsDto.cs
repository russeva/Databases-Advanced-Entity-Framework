using System.ComponentModel.DataAnnotations;

namespace Instagraph.DataProcessor.Dto.Import
{
    public class ImportPicsDto
    {
        [Required]
        public string Path { get; set; }

        public decimal Size { get; set; } 
    }
}
