using System.ComponentModel.DataAnnotations;
using TasksApi.Helpers;

namespace TasksApi.Dtos.Tasks
{
    public class UpdateTaskDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Status status { get; set; }
        [Required]
        public Priority priority { get; set; }
        public DateTime? CompletedAt { get; set; } = DateTime.Today;
        [Required]
        public int categoryId { get; set; }

    }
}
