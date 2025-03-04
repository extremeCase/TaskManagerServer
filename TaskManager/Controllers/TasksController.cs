using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var (tasks, errorMessage) = await _taskService.GetAllTasks();
            if (tasks == null)
                return BadRequest(errorMessage);

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var (task, errorMessage) = await _taskService.GetTaskById(id);
            if (task == null)
                return NotFound(errorMessage);

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] TaskItemDto task)
        {
            var (addedTask, errorMessage) = await _taskService.AddTask(task);
            if (addedTask == null)
                return BadRequest(errorMessage);

            return CreatedAtAction(nameof(GetTaskById), new { id = addedTask.id }, addedTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskItemDto task)
        {
            if (id != task.id)
                return BadRequest("Task ID mismatch");

            var (updatedTask, errorMessage) = await _taskService.UpdateTask(task);
            if (updatedTask == null)
                return BadRequest(errorMessage);

            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var (isSuccess, errorMessage) = await _taskService.DeleteTask(id);
            if (!isSuccess)
                return BadRequest(errorMessage);

            return NoContent();
        }
    }
}
