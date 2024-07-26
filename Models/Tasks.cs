using TasksApi.Helpers;

namespace TasksApi.Models
{
    public class Tasks
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
        public int categoryId { get; set; }
        public Category category { get; set; }
        public string userId { get; set; }
        public User user { get; set; }
    }
}
