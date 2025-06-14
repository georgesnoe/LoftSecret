using System.ComponentModel.DataAnnotations;

namespace LoftSecret.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Veuillez spécifier votre adresse email")]
    [EmailAddress]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Veuillez spécifier votre mot de passe")]
    [DataType(DataType.Password)]
    [Length(8, 30, ErrorMessage = "Le mot de passe doit être au minimum de 8 caractères")]
    public required string MotDePasse { get; set; }
}
