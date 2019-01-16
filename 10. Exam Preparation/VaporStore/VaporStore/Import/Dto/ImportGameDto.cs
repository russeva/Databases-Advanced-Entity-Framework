namespace VaporStore.Import.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ImportGameDto
    {
        [Required]
        public string Name { get; set; }

        [Range(minimum: 0, maximum: double.MaxValue)]
        [Required]
        public double Price { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTime ReleaseDate { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Developer { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Genre { get; set; }

        [Required]
        [MinLength(1)]
        public string[] Tags { get; set; }
    }
}
