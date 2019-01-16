namespace VaporStore.Data.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VaporStore.Data.Models.Enum;

    public class Card
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^\d{4} \d{4} \d{4} \d{4}$")]
        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}$")]
        public string Cvc { get; set; }

        [Required]
        public CardType Type{ get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

        public ICollection<Purchase> Purchases{ get; set; }
    }
}
