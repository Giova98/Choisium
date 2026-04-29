namespace Domain.Entity
{
    public class Project
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public StateProject StateProject { get; set; }
        public Guid UserId { get; set; }   
        public User User { get; set; } = null!; 

        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
    public enum StateProject
    {
        AwaitingProject,
        CompletedProject,
        CancelledProject
    }
}