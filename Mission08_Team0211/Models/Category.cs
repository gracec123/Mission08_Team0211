using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0211.Models
{
    // Represents a category entity
    public class Category
    {

        [Key]
        [Required]
        public int CategoryId { get; set; } // Primary key for the category
        [Required]
        public string? CategoryName { get; set; } // Name of the category

    }
}
