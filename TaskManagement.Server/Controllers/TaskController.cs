using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.Server.Controllers
{
 
    using Microsoft.AspNetCore.Mvc;
    using TaskManagement.Models;
  
    using TaskManagement.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _taskService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("tasks")]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _taskService.GetTasksAsync();
            return Ok(tasks);
        }

        [HttpPost("task")]
        public async Task<IActionResult> AddTask([FromBody] Task task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var addedTask = await _taskService.AddTaskAsync(task);
            return Ok(addedTask);
        }

        [HttpDelete("task/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await _taskService.DeleteTaskAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }

}
