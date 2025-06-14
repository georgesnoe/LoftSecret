namespace LoftSecret.Models;

public class Medias
{
    public int? Id { get; set; }
    public required string Lien { get; set; }

    // --- Foreign Key ---
    public int EmplacementId { get; set; }
}