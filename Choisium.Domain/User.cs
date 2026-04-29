using System.ComponentModel.DataAnnotations;

namespace Choisium.Domain;

public class User
{
    [Key]
    public Guid Id {get; set;}
    [Required]
    public int NameAndLastName {get; set;}

    [Required]
    public string Email {get; set;}
    public string Password {get; set;}
}
