using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0211.Models
{
    public class AllTasks
    {
        [Key]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task name is required.")]
        public string Name { get; set; }


        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }


        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; } = DateTime.Today;


        [Required(ErrorMessage = "Quadrant is required.")]
        public int Quadrant { get; set; } // Assuming quadrant is represented by an integer

        public bool? Completed { get; set; } = false;


    }
}
