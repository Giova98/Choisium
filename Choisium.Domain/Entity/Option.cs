namespace Choisium.Domain.Entity
{
    public class Option : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Score { get; set; }
        public StateOption StateOption { get; set; }
        public Guid DecisionTaskId { get; set; } 
        public DecisionTask DecisionTask { get; set; } = null!;
    }

    public enum StateOption
    {
        PendingOption,
        CompletedOption,
        CancelledOption
    }
}