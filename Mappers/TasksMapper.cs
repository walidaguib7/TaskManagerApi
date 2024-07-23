using TasksApi.Dtos.Tasks;
using TasksApi.Models;

namespace TasksApi.Mappers
{
    public static class TasksMapper
    {
        public static Tasks ToTask(this CreateTaskDto dto)
        {
            return new Tasks
            {
                Name = dto.Name,
                Description = dto.Description,
                status = dto.status,
                priority = dto.priority,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = null ,
                CompletedAt = null ,
                categoryId = dto.categoryId,
                userId = dto.userId 
            };
        }

        public static TasksDto ToTaskDto(this Tasks task)
        {
            return new TasksDto
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                status = task.status,
                priority = task.priority,
                CreatedAt = task.CreatedAt,
                UpdatedAt = task.UpdatedAt,
                CompletedAt = task.CompletedAt,
                username = task.user.UserName,
                categoryName = task.category.Name
            };
        }
    }
}
