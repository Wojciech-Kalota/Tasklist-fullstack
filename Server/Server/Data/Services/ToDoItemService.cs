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

        public void AddTask(TodoItemVM task)
        {
            var _task = new TodoItem()
            {
                Name = task.Name,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                Deadline = task.Deadline
            };

            _context.ToDoItems.Add(_task);
            _context.SaveChanges();
        }

        public void UpdateTask(uint taskID, TodoItemVM task)
        {
            var _task = _context.ToDoItems.FirstOrDefault(n => n.Id == taskID);

            if(_task != null)
            {
                _task.Name = task.Name;
                _task.Description = task.Description;
                _task.IsCompleted = task.IsCompleted;
                _task.Deadline = task.Deadline;
                        
                _context.SaveChanges();
            }
        }

        public List<TodoItem> GetAllTasks() => _context.ToDoItems.ToList();

        public void RemoveTask(uint taskID) 
        {
            var _task = _context.ToDoItems.FirstOrDefault(n => n.Id == taskID);

            if(_task != null ) 
            {
                _context.ToDoItems.Remove(_task);
                _context.SaveChanges();
            }
        }
    }
}
