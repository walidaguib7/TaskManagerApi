﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TasksApi.Data;
using TasksApi.Dtos.Tasks;
using TasksApi.Helpers;
using TasksApi.Models;
using TasksApi.Services;

namespace TasksApi.Repositories
{
    public class TasksRepo(
        ApplicationDBContext _context ,
        [FromKeyedServices("tasks")] IValidator<Tasks> _validator) : ITasks
    {
        private readonly ApplicationDBContext context = _context;
        private readonly IValidator<Tasks> validator = _validator;
        public async Task<Tasks?> CreateTask(Tasks task)
        {
            var result = validator.Validate(task);
            if (result.IsValid) {
                await context.tasks.AddAsync(task);
                await context.SaveChangesAsync();
                return task;
            }else
            {
                throw new ValidationException(result.Errors);
            }
            
        }

        public async Task<Tasks?> DeleteTask(int id)
        {
            var task = await context.tasks.FindAsync(id);
            if (task == null) return null;
            context.tasks.Remove(task);
            await context.SaveChangesAsync();
            return task;
        }

        public async Task<List<Tasks>> GetAllTasks(PostQuery query , string userId)
        {
            var tasks = context.tasks
                .Include(t => t.category)
                .Include(t => t.user)
                .Where(t => t.userId == userId)
                .AsQueryable();
            if (!string.IsNullOrEmpty(query.Name))
            {
                tasks = tasks.Where(b => b.Name.Contains(query.Name));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    tasks = query.IsDescending ? tasks.OrderByDescending(s => s.Name) : tasks.OrderBy(s => s.Name);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.Limit;
            return await tasks.Skip(skipNumber).Take(query.Limit).ToListAsync();
        }

        public async Task<Tasks?> GetTask(int id)
        {
            return await context.tasks.Include(t => t.category)
                .Include(t => t.user).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Tasks?> UpdateTask(int id, UpdateTaskDto dto)
        {
            var task = await context.tasks.FindAsync(id);
            var result = validator.Validate(task);
            if (result.IsValid)
            {
                task.Name = dto.Name;
                task.Description = dto.Description;
                task.status = dto.status;
                task.priority = dto.priority;
                task.UpdatedAt = DateOnly.FromDateTime(DateTime.Today);
                task.CompletedAt = dto.CompletedAt;
                task.categoryId = dto.categoryId;
                task.Due_Date = dto.Due_Date;
                await context.SaveChangesAsync();
                return task;
            }else
            {
             return null;
            }
            
        }
    }
}
