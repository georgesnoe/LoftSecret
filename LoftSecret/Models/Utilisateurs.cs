public class Utilisateurs
{
    public int? Id { get; set; }
    public required string Nom { get; set; }
    public required string Prenoms { get; set; }
    // public DateTimeOffset? DateDeNaissance { get; set; }
    public required string Telephone { get; set; }
    public required string Email { get; set; }
    public required string MotDePasse { get; set; }
    public DateTimeOffset DateInscription { get; set; }
    public int RoleId { get; set; }
}