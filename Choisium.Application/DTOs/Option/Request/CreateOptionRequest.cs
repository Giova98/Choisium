using System.ComponentModel.DataAnnotations;

namespace Choisium.Application.DTOs.Option.Request
{
    public class CreateOptionRequest
    {
        [Required(ErrorMessage = "El nombre de la opción es obligatorio")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 200 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "El puntaje no puede ser negativo")]
        public decimal Score { get; set; }

        public StateOption StateOption { get; set; } = StateOption.PendingOption;
    }

    public enum StateOption
    {
        PendingOption,
        CompletedOption,
        CancelledOption
    }
}