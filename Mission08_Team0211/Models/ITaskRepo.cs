namespace Mission08_Team0211.Models
{
    public interface ITaskRepo
    {
        List<Category> Categories { get; }


        void AddTask(MyTasks task);
        void EditTask(MyTasks task);
        void DeleteTask(int taskId);
    }
}
