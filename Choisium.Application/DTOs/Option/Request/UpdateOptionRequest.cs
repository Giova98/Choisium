using System.ComponentModel.DataAnnotations;

namespace Choisium.Application.DTOs.Option.Request
{
    public class UpdateOptionRequest
    {
        [Required(ErrorMessage = "El nombre de la opción es obligatorio")]
        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "El puntaje no puede ser negativo")]
        public decimal Score { get; set; }

        public StateOption StateOption { get; set; }
    }
}