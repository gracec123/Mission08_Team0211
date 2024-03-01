using SQLitePCL;

namespace Mission08_Team0211.Models
{
    // Implementation of ITaskRepo using Entity Framework
    public class EFTaskRepo: ITaskRepo
    {
        private TaskContext _context;

        // Constructor
        public EFTaskRepo(TaskContext temp) 
        {
            _context = temp;
        }

        // Gets all categories
        public List<Category> Categories => _context.Categories.ToList();


        // Gets all tasks
        public List<AllTasks> AllTasks => _context.AllTasks.ToList();


        // Adds a new task
        public void AddTask(AllTasks task)
        {
            _context.AllTasks.Add(task); 
            _context.SaveChanges();
        }

        // Edits an existing task
        public void EditTask(AllTasks task)
        {
            _context.AllTasks.Update(task); 
            _context.SaveChanges(); 
        }

        // Deletes a task by ID
        public void DeleteTask(int taskId)
        {
            var taskToDelete = _context.AllTasks.FirstOrDefault(t => t.TaskId == taskId); // Finds the task by ID
            if (taskToDelete != null)
            {
                _context.AllTasks.Remove(taskToDelete); 
                _context.SaveChanges(); 
            }
        }


    }
}
