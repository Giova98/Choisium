namespace Choisium.Domain.Entity
{
    public class DecisionTask : BaseEntity
    {
        public string? Reason { get; set; }
        public StateTask StateTask { get; set; }
        public Guid ProjectId { get; set; } 
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