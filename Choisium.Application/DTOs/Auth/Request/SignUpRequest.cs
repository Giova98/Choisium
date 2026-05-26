using System.ComponentModel.DataAnnotations;

namespace Choisium.Application.DTOs.Auth.Request
{
    public class SignUpRequest
    {
        [Required(ErrorMessage = "El nombre completo es obligatorio")]
        public string FullName {get; set;} = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato de email no es valido")]
        public string Email {get; set;} = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener entre {2} y {1} caracteres.")]
        public string Password {get; set;}  = string.Empty;
    }
}