using System.ComponentModel.DataAnnotations;
using TasksApi.Helpers;

namespace TasksApi.Dtos.Tasks
{
    public class CreateTaskDto
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public Status status { get; set; }

        public Priority priority { get; set; }
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Today);

        public DateOnly Due_Date { get; set; } = DateOnly.FromDateTime(DateTime.Today);

        public int categoryId { get; set; }

        public string userId { get; set; }

    }
}
