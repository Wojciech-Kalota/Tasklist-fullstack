using Microsoft.AspNetCore.Mvc;
using Server.Data.Services;
using Server.Data.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public TaskService _taskService;

        public TodoController(TaskService taskService)
        {
            _taskService = taskService;
        }
        /*
        [HttpPost("add-task")]
        public IActionResult AddTask([FromBody]TodoItemVM task)
        {
            _taskService.AddTask(task);
            return Ok();
        }
        */
    }
}
