using DataAccessLibrary.Models;

namespace DataAccessLibrary.Data;

public interface IDatabaseData
{
    /// <summary>
    ///     The function is responsible for displaying available room types in a calendar range
    /// </summary>
    /// <param name="startDate">Check-in day</param>
    /// <param name="endDate">Check-out day</param>
    /// <returns>Returns a list of room types available in a given calendar date range</returns>
    List<RoomTypesDto> GetAvailableRoomTypes(DateTime startDate, DateTime endDate);

    /// <summary>
    ///     The method that is responsible for booking a guest in a hotel room, based on the criteria of name, last name,
    ///     date range and type of room desired, following the rooms availability.
    /// </summary>
    /// <param name="firstName">Guest's first name</param>
    /// <param name="lastName">Guest's last name</param>
    /// <param name="startDate">Check-in day</param>
    /// <param name="endDate">Check-out day</param>
    /// <param name="roomTypeId">Camera type identification Id</param>
    void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId);

    /// <summary>
    ///     The method is responsible for displaying hotel room bookings based on date and first name.
    /// </summary>
    /// <param name="firstName">Guest's first name</param>
    /// <returns>Reservations for a guest on a particular day, based on first name criteria. </returns>
    List<BookingsDto> SearchBookings(string firstName);

    /// <summary>
    ///     The method is responsible for confirming the guest check-in
    /// </summary>
    /// <param name="bookingId">Booking identification number</param>
    void CheckInGuest(int bookingId);
}