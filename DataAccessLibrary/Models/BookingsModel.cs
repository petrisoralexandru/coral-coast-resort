namespace DataAccessLibrary.Models;

/// <summary>
///     Model class that holds all the properties required to make a hotel room reservation.
///     Contains properties from all tables in the database.
/// </summary>
public class BookingsModel
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int GuestId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool CheckedIn { get; set; }
    public decimal TotalCost { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int RoomTypeId { get; set; }
    public string? RoomNumber { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}