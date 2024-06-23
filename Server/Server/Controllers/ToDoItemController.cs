using Microsoft.AspNetCore.Mvc;
using Server.Data.Services;
using Server.Data.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public ToDoItemService _taskService;

        public TodoController(ToDoItemService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost("add-todoitem")]
        public async Task<IActionResult> AddTask([FromBody] TodoItemVM task)
        {
            await _taskService.AddTaskAsync(task);
            return Ok();
        }

        [HttpGet("get-todoitems")]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpDelete("remove-todoitem/{id}")]
        public async Task<IActionResult> RemoveTask(uint id)
        {
            await _taskService.RemoveTaskAsync(id);
            return Ok();
        }
    }
}