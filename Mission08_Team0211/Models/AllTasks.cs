using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0211.Models
{
    // Represents a task entity
    public class AllTasks
    {
        // Primary key for the task
        [Key]
        public int TaskId { get; set; }

        // Name of the task
        [Required(ErrorMessage = "Task name is required.")]
        public string? Name { get; set; }

        // Foreign key for category
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        // Due date of the task, default to today
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; } = DateTime.Today;


        // Quadrant of the task
        [Required(ErrorMessage = "Quadrant is required.")]
        public int Quadrant { get; set; }

        // Indicates whether the task is completed or not
        public bool? Completed { get; set; } = false;


    }
}
