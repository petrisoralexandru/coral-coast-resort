using DataAccessLibrary.Databases.SQLServer;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Data;

public class SqlData : IDatabaseData
{
    private readonly ISqlDataAccess _db;
    private const string ConnectionStringName = "SqlServerDB";

    public SqlData(ISqlDataAccess db)
    {
        _db = db;
    }

    /// <summary>
    ///     The function is responsible for displaying available room types in a calendar range
    /// </summary>
    /// <param name="startDate">Check-in day</param>
    /// <param name="endDate">Check-out day</param>
    /// <returns>Returns a list of room types available in a given calendar date range</returns>
    public List<RoomTypesDto> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
    {
        return _db.LoadData<RoomTypesDto, dynamic>("dbo.RoomTypes_GetAvailableTypes", new { startDate, endDate },
            ConnectionStringName, true);
    }

    /// <summary>
    ///     The method that is responsible for booking a guest in a hotel room, based on the criteria of name, last name,
    ///     date range and type of room desired, following the rooms availability.
    /// </summary>
    /// <param name="firstName">Guest's first name</param>
    /// <param name="lastName">Guest's last name</param>
    /// <param name="startDate">Check-in day</param>
    /// <param name="endDate">Check-out day</param>
    /// <param name="roomTypeId">Camera type identification Id</param>
    public void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId)
    {
        var guest = _db
            .LoadData<GuestDto, dynamic>("dbo.Guests_Insert", new { firstName, lastName }, ConnectionStringName, true)
            .First();

        var roomType =
            _db.LoadData<RoomTypesDto, dynamic>("dbo.RoomTypes_GetRoomTypeById", new { id = roomTypeId },
                ConnectionStringName, true).First();

        var timeStaying = endDate.Date.Subtract(startDate.Date);

        var availableRooms = _db.LoadData<RoomDto, dynamic>("dbo.Rooms_GetAvailableRooms",
            new { startDate, endDate, roomTypeId }, ConnectionStringName, true);

        _db.SaveData("dbo.Bookings_Insert",
            new
            {
                roomId = availableRooms.First().Id,
                guestId = guest.Id,
                startDate,
                endDate,
                totalCost = timeStaying.Days * roomType.Price
            },
            ConnectionStringName, true);
    }

    /// <summary>
    ///     The method is responsible for displaying hotel room bookings based on date and first name.
    /// </summary>
    /// <param name="firstName">Guest's first name</param>
    /// <returns>Reservations for a guest on today date, based on first name criteria.</returns>
    public List<BookingsDto> SearchBookings(string firstName)
    {
        return _db.LoadData<BookingsDto, dynamic>("dbo.Bookings_SearchBookings",
            new { firstName, startDate = DateTime.Now.Date },
            ConnectionStringName, true);
    }

    /// <summary>
    ///     The method is responsible for confirming the guest check-in
    /// </summary>
    /// <param name="bookingId">Booking identification number</param>
    public void CheckInGuest(int bookingId)
    {
        _db.SaveData("dbo.Bookings_CheckIn", new { bookingId }, ConnectionStringName, true);
    }

    /// <summary>
    ///     The method is responsible for retrieving a room type based on a identification number 
    /// </summary>
    /// <param name="id">The identification number of the room type</param>
    /// <returns>All the details about a room type</returns>
    public RoomTypesDto? GetRoomTypeById(int id)
    {
        return _db.LoadData<RoomTypesDto, dynamic>("dbo.RoomTypes_GetRoomTypeById", new { id }, ConnectionStringName,
            true).FirstOrDefault();
    }
}