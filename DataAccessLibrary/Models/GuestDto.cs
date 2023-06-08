namespace DataAccessLibrary.Models;

/// <summary>
///     DTO (data transfer object) that holds all the properties of the hotel guest
/// </summary>
public class GuestDto
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}