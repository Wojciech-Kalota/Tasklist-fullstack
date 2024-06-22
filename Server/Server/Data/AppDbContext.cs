﻿using Microsoft.EntityFrameworkCore;
using Server.Data.Models;

namespace Server.Data
{
    public class AppDbContext : DbContext
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        { 

        }

        public DbSet<TodoItem> Tasks { get; set; }
    
    }
}
