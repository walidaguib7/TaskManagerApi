using System.ComponentModel.DataAnnotations;
using TasksApi.Helpers;

namespace TasksApi.Dtos.Tasks
{
    public class UpdateTaskDto
    {

        public string Name { get; set; }

        public string Description { get; set; }
 
        public Status status { get; set; }
 
        public Priority priority { get; set; }
        public DateOnly? CompletedAt { get; set; } 
        public DateOnly Due_Date { get; set; } 

        public int categoryId { get; set; }

    }
}
