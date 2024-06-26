using Microsoft.EntityFrameworkCore;
using Server.Data.Models;

namespace Server.Data.Services
{
    public class ToDoItemService
    {
        private AppDbContext _context;

        public ToDoItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddTaskAsync(TodoItemVM task)
        {
            var _task = new TodoItem()
            {
                Name = task.Name,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                Deadline = task.Deadline
            };

            _context.ToDoItems.Add(_task);
            await _context.SaveChangesAsync();
        }

        public Task<List<TodoItem>> GetAllTasksAsync() =>
           _context.ToDoItems.ToListAsync();

        public async Task RemoveTaskAsync(uint taskID)
        {
            var sql = $"DELETE FROM ToDoItems WHERE Id = {taskID}";
            await _context.Database.ExecuteSqlRawAsync(sql);
        }
    }
}
