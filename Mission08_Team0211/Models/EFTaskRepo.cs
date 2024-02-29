using SQLitePCL;

namespace Mission08_Team0211.Models
{
    public class EFTaskRepo: ITaskRepo
    {
        private TaskContext _context;
        public EFTaskRepo(TaskContext temp) 
        {
            _context = temp;
        }
        public List<Category> Categories => _context.Categories.ToList();

        public List<AllTasks> AllTasks => _context.AllTasks.ToList();

        public void AddTask(AllTasks task)
        {
            _context.AllTasks.Add(task); 
            _context.SaveChanges();
        }

        public void EditTask(AllTasks task)
        {
            _context.AllTasks.Update(task); 
            _context.SaveChanges(); 
        }

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
