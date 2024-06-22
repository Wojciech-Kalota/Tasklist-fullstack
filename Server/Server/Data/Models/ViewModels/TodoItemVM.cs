namespace Server.Data.Models
{
    public class TodoItemVM
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? Deadline { get; set; }
    }
}
