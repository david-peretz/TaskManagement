namespace TaskManagement.Services
{
   
    using Microsoft.EntityFrameworkCore;
    using TaskManagement.Models;
    using TaskManagement.Data;


    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<Task>> GetTasksAsync()
        {
            return await _context.Tasks.Include(t => t.User).ToListAsync();
        }

        public async Task<Task> AddTaskAsync(Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
