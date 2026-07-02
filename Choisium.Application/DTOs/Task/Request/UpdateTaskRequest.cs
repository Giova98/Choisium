using System.ComponentModel.DataAnnotations;

namespace Choisium.Application.DTOs.Task.Request
{
    public class UpdateTaskRequest
    {
        [Required(ErrorMessage = "El motivo de la tarea es obligatorio")]
        [StringLength(500, MinimumLength = 3)]
        public string Reason { get; set; } = string.Empty;

        public StateTask StateTask { get; set; }
    }
}