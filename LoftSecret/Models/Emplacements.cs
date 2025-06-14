public class Emplacements
{
    public int? Id { get; set; }
    public required string Nom { get; set; }
    public required string Description { get; set; }
    public int? Superficie { get; set; }
    public required int CapaciteMax { get; set; }
    public int Prix { get; set; }

    // --- Foreign Keys ---
    public int LocalisationId { get; set; }
    public int UtilisateurId { get; set; }
}