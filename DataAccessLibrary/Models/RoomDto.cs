namespace DataAccessLibrary.Models;

/// <summary>
///     DTO (data transfer object) that holds all the properties of a hotel room
/// </summary>
public class RoomDto
{
    public int Id { get; set; }
    public int RoomNumber { get; set; }
    public int RoomTypeId { get; set; }
}