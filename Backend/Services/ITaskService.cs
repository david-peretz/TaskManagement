namespace TaskManagement.Services
{

    using TaskManagement.Models;


    public interface ITaskService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<Task>> GetTasksAsync();
        Task<Task> AddTaskAsync(Task task);
        Task<bool> DeleteTaskAsync(int taskId);
    }

}
