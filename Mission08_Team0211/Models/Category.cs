﻿using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0211.Models
{
    public class Category
    {

        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }

    }
}
