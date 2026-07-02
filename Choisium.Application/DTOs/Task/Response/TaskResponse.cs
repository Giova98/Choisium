namespace Choisium.Application.DTOs.Task.Response
{
    public class TaskResponse
    {
        public Guid Id { get; set; }
        public string Reason { get; set; } = string.Empty;
        public StateTask StateTask { get; set; }
        public Guid ProjectId { get; set; }
    }

    public enum StateTask
    {
        AwaitingTask,
        CompletedTask,
        CancelledTask
    }
}