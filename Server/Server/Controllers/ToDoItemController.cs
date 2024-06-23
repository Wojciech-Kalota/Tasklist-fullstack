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
        public IActionResult AddTask([FromBody]TodoItemVM task)
        {
            _taskService.AddTask(task);
            return Ok();
        }

        [HttpPut("update-todoitem/{id}")]
        public IActionResult UpdateTask(uint id, [FromBody] TodoItemVM task)
        {
            _taskService.UpdateTask(id, task);
            return Ok();
        }

        [HttpGet("get-todoitems")]
        public IActionResult GetTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpDelete("remove-todoitem/{id}")]
        public IActionResult RemoveTask(uint id)
        {
            _taskService.RemoveTask(id);
            return Ok();
        }
    }
}
