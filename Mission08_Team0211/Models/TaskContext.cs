using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Mission08_Team0211.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        public DbSet<AllTasks> AllTasks { get; set; }

        public DbSet<Category> Categories { get; set; }
       // public DbSet<AllTasks> Tasks { get; set; }


    }
}
