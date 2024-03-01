using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Mission08_Team0211.Models
{
    // Represents the database context for tasks
    public class TaskContext : DbContext
    {

        // Constructor
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        // DbSet for tasks
        public DbSet<AllTasks> AllTasks { get; set; }

        // DbSet for categories
        public DbSet<Category> Categories { get; set; }



    }
}
