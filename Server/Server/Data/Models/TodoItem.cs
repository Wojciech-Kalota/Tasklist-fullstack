namespace Server.Data.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? Deadline { get; set; }
        public DateTime LastModified { get; set; } = DateTime.Now;
    }
}
