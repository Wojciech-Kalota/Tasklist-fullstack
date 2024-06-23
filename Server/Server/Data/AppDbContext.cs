using Microsoft.EntityFrameworkCore;
using Server.Data.Models;

namespace Server.Data
{
    public class AppDbContext : DbContext
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        { 
            Database.EnsureCreated();
        }

        public DbSet<TodoItem> ToDoItems { get; set; }
    
    }
}
