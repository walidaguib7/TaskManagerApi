using System.ComponentModel.DataAnnotations;
using TasksApi.Helpers;

namespace TasksApi.Dtos.Tasks
{
    public class CreateTaskDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Status status { get; set; }
        [Required]
        public Priority priority { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Today;
        [Required]
        public int categoryId { get; set; }
        [Required]
        public string userId { get; set; }

    }
}
