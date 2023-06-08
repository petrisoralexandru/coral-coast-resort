namespace DataAccessLibrary.Models;

/// <summary>
///     DTO (data transfer object) that holds all the properties of the RoomTypes table.
/// </summary>
public class RoomTypesDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}