namespace VaporStore.Import.Dto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using VaporStore.Data.Models.Enum;

    public class ImportCardDto
    {
        [RegularExpression(@"^\d{4} \d{4} \d{4} \d{4}$")]
        [Required]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}$")]
        public string Cvc { get; set; }

        [Required]
        public CardType Type { get; set; }
    }
}
