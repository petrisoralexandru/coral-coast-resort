namespace DataAccessLibrary.Models;

/// <summary>
///     Model class that holds all the properties of a hotel room
/// </summary>
public class RoomModel
{
    public int Id { get; set; }
    public int RoomNumber { get; set; }
    public int RoomTypeId { get; set; }
}