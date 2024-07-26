using TasksApi.Helpers;

namespace TasksApi.Dtos.Tasks
{
    public class TasksDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status status { get; set; }
        public Priority priority { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateOnly? UpdatedAt { get; set; }
        public DateOnly? CompletedAt { get; set; }
        public DateOnly Due_Date { get; set; } 
        public string categoryName { get; set; }
        public string username { get; set; }

    }
}
