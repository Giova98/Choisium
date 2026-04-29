namespace Domain.Entity
{
    public class Option
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Score { get; set; }

        public StateOption StateOption { get; set; }

        public int TaskId { get; set; } 
        public Task Task { get; set; } = null!;
    }

    public enum StateOption
    {
        PendingOption,
        CompletedOption,
        CancelledOption
    }
}