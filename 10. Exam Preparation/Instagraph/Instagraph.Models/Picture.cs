﻿namespace Instagraph.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Picture
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public decimal Size { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();

        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
