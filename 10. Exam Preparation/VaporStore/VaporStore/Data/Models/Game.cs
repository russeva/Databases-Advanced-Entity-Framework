namespace VaporStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(minimum: 0,maximum: double.MaxValue)]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [ForeignKey("Developer")]
        public int DeveloperId { get; set; }

        [Required]
        public Developer Developer { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

        [Required]
        public ICollection<GameTag> GameTags { get; set; }
    }
}
