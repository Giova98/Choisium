namespace Choisium.Domain.Entity
{
    public class Project : BaseEntity
    {
        public string Name {get; set;} = string.Empty;
        public string Description { get; set; } = string.Empty;
        public StateProject StateProject { get; set; }
        public Guid UserId { get; set; }   
        public User User { get; set; } = null!; 
        public ICollection<DecisionTask> DecisionTasks { get; set; } = new List<DecisionTask>();
        public DateTime CreatedAt { get; set; }
    }
    public enum StateProject
    {
        AwaitingProject,
        CompletedProject,
        CancelledProject
    }
}