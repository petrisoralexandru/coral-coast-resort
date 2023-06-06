namespace DataAccessLibrary.Models;

/// <summary>
///     Model class that holds all the properties of the hotel guest
/// </summary>
public class GuestModel
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}