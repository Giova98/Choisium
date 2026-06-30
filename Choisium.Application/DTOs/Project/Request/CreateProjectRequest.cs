using System.ComponentModel.DataAnnotations;

namespace Choisium.Application.DTOs.Project.Request
{
    public class CreateProjectRequest
    {
        [Required(ErrorMessage = "El nombre del proyecto es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres")]
        public string Description { get; set; } = string.Empty;

        public StateProject StateProject { get; set; } = StateProject.AwaitingProject;
        public DateTime CreatedAt { get; set; }
    }

    public enum StateProject
    {
        AwaitingProject,
        CompletedProject,
        CancelledProject
    }
}