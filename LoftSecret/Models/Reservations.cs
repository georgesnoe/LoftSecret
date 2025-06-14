namespace LoftSecret.Models;

public class Reservations
{
    public int Id { get; set; }
    public DateTimeOffset DebutReservation { get; set; }
    public DateTimeOffset FinReservation { get; set; }

    // --- Foreign Keys ---
    public int UtilisateurId { get; set; }
    public int EmplacementId { get; set; }
    public int StatusId { get; set; }
}