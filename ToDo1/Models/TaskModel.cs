using System.ComponentModel.DataAnnotations;

namespace ToDo1.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly DueDate { get; set; }

    }
}
