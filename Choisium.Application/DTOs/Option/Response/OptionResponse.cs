namespace Choisium.Application.DTOs.Option.Response
{
    public class OptionResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Score { get; set; }
        public StateOption StateOption { get; set; }
        public Guid DecisionTaskId { get; set; }
    }

    public enum StateOption
    {
        PendingOption,
        CompletedOption,
        CancelledOption
    }
}