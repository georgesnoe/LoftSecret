namespace LoftSecret.Models;

public class Temoignages
{
    public int? Id { get; set; }
    public string? Texte { get; set; }
    public required int Vote { get; set; } // The rating (1 to 10)
    public DateTimeOffset Date { get; set; }

    // --- Foreign Keys ---
    public int UtilisateurId { get; set; }
    public int EmplacementId { get; set; }
}