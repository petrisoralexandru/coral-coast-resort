namespace DataAccessLibrary.Models;

/// <summary>
///     Model class that holds all the properties of the RoomTypes table.
/// </summary>
public class RoomTypesModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}