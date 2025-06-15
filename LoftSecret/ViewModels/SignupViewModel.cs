using System.ComponentModel.DataAnnotations;

namespace LoftSecret.ViewModels;

public class SignupViewModel
{
    [Required(ErrorMessage = "Veuillez spécifier votre nom")]
    public required string Nom { get; set; }

    [Required(ErrorMessage = "Veuillez spécifier votre prénom")]
    public required string Prenoms { get; set; }

    [Required(ErrorMessage = "Veuillez spécifier votre numéro de téléphone")]
    [Phone(ErrorMessage = "Veuillez respecter le format des numéros de téléphone")]
    [Length(8, 20, ErrorMessage = "Veuillez respecter le format des numéros de téléphone")]
    public required string Telephone { get; set; }

    [Required(ErrorMessage = "Veuillez spécifier votre adresse email")]
    [EmailAddress]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Veuillez préciser votre role")]
    [AllowedValues([1, 2], ErrorMessage = "Veuillez choisir votre role")]
    public int RoleId { get; set; }

    [Required(ErrorMessage = "Veuillez spécifier votre mot de passe")]
    [DataType(DataType.Password)]
    [Length(8, 30, ErrorMessage = "Le mot de passe doit être au minimum de 8 caractères")]
    [Compare("ConfirmerMotDePasse", ErrorMessage = "Les mots de passe ne correspondent pas")]
    public required string MotDePasse { get; set; }

    [Required(ErrorMessage = "Veuillez confirmer votre mot de passe")]
    [DataType(DataType.Password)]
    [Compare("MotDePasse", ErrorMessage = "Les mots de passe ne correspondent pas")]
    public required string ConfirmerMotDePasse { get; set; }


    public override string ToString()
    {
        return "";
    }
}