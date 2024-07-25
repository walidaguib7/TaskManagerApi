using TasksApi.Dtos.Tasks;
using TasksApi.Helpers;
using TasksApi.Models;

namespace TasksApi.Services
{
    public interface ITasks
    {
        public Task<List<Tasks>> GetAllTasks(PostQuery query , string userId);
        public Task<Tasks?> GetTask(int id);
        public Task<Tasks> CreateTask(Tasks task);
        public Task<Tasks?> UpdateTask(int id, UpdateTaskDto dto);
        public Task<Tasks?> DeleteTask(int id);
    }
}
