namespace TaskManagement.Models
{
    public class Task
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Subject { get; set; }
        public DateTime TargetDate { get; set; }
        public bool IsCompleted { get; set; }
        public User User { get; set; }
    }
}
