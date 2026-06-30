using System.ComponentModel.DataAnnotations;

namespace Choisium.Application.DTOs.Project.Request
{
    public class UpdateProjectRequest
    {
        [Required(ErrorMessage = "El nombre del proyecto es obligatorio")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        public StateProject StateProject { get; set; }
    }
}