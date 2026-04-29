namespace Domain.Entity
{
    public class Task
    {
        public int Id { get; set; }
        public string? Reason { get; set; }
        public StateTask StateTask { get; set; }
        public int ProjectId { get; set; } 
        public Project Project { get; set; } = null!;

        public ICollection<Option> Options { get; set; } = new List<Option>();
    }
    public enum StateTask
    {
        AwaitingTask,
        CompletedTask,
        CancelledTask
    }
}