using System.ComponentModel.DataAnnotations;

namespace Choisium.Application.DTOs.Task.Request
{
    public class CreateTaskRequest
    {
        [Required(ErrorMessage = "El motivo de la tarea es obligatorio")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "El motivo debe tener entre 3 y 500 caracteres")]
        public string Reason { get; set; } = string.Empty;

        public StateTask StateTask { get; set; } = StateTask.AwaitingTask;
    }

    public enum StateTask
    {
        AwaitingTask,
        CompletedTask,
        CancelledTask
    }
}