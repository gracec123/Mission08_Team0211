namespace Mission08_Team0211.Models
{
    // Interface for Task Repository
    public interface ITaskRepo
    {
        // Gets all categories
        List<Category> Categories { get; }

        // Gets all tasks
        List<AllTasks> AllTasks { get; }

        // Adds a new task
        void AddTask(AllTasks task);

        // Edits an existing task
        void EditTask(AllTasks task);

        // Deletes a task by ID
        void DeleteTask(int taskId);
    }
}
