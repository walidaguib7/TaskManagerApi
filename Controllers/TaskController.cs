using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TasksApi.Dtos.Tasks;
using TasksApi.Helpers;
using TasksApi.Mappers;
using TasksApi.Services;

namespace TasksApi.Controllers
{
    [Route("api/Tasks")]
    [ApiController]
    public class TaskController(ITasks _tasksService) : ControllerBase
    {
        private readonly ITasks tasksService = _tasksService;


        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetAllTasks([FromQuery] PostQuery query , [FromRoute] string userId)
        {
            var tasks = await tasksService.GetAllTasks(query , userId);
            var task = tasks.Select(t => t.ToTaskDto());
            return Ok(task);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetTask([FromRoute] int id)
        {
            var task = await tasksService.GetTask(id);
            if (task == null) return NotFound();
            return Ok(task.ToTaskDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var taskModel = dto.ToTask();
            var task = await tasksService.CreateTask(taskModel);
            if (task == null) return StatusCode(400);
            return Created();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateTask([FromRoute] int id , [FromBody] UpdateTaskDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var task = await tasksService.UpdateTask(id, dto);
            if (task == null) return NotFound();
            return Ok("Task updated!");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            var task = await tasksService.DeleteTask(id);
            if (task == null) return NotFound();
            return Ok("task deleted!");
        }
    }
}
