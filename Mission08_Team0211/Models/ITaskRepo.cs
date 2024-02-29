namespace Mission08_Team0211.Models
{
    public interface ITaskRepo
    {
        List<Category> Categories { get; }


        void AddTask(AllTasks task);
        void EditTask(AllTasks task);
        void DeleteTask(int taskId);
    }
}
