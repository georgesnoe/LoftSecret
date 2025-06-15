using System.ComponentModel.DataAnnotations;

namespace LoftSecret.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Veuillez spécifier votre adresse email")]
    [EmailAddress(ErrorMessage = "Le format de l'adresse email est invalide")]
    [DeniedValues([Database.Database.SQL_EMAIL_NOT_EXISTS_STR], ErrorMessage = "Cette adresse email n'existe pas")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Veuillez spécifier votre mot de passe")]
    [DataType(DataType.Password)]
    [DeniedValues([Database.Database.SQL_PASSWORD_ERROR_STR], ErrorMessage = "Le mot de passe fourni est incorrect")]
    [Length(8, 30, ErrorMessage = "Le mot de passe doit être au minimum de 8 caractères")]
    public required string MotDePasse { get; set; }
}
