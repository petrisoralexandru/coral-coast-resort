using DataAccessLibrary.Models;

namespace DataAccessLibrary;

public class SqlData
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
    public List<RoomTypesModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
    {
        return _db.LoadData<RoomTypesModel, dynamic>("dbo.RoomTypes_GetAvailableTypes", new { startDate, endDate },
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
            .LoadData<GuestModel, dynamic>("dbo.Guests_Insert", new { firstName, lastName }, ConnectionStringName, true)
            .First();

        var roomType =
            _db.LoadData<RoomTypesModel, dynamic>("dbo.RoomTypes_GetRoomTypeById", new { roomTypeId },
                ConnectionStringName, true).First();

        var timeStaying = endDate.Date.Subtract(startDate.Date);

        var availableRooms = _db.LoadData<RoomModel, dynamic>("dbo.Rooms_GetAvailableRooms",
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
    /// <returns>Reservations for a guest on a particular day, based on first name criteria. </returns>
    public List<BookingsModel> SearchBookings(string firstName)
    {
        return _db.LoadData<BookingsModel, dynamic>("dbo.Bookings_SearchBookings",
            new { firstName, startDate = DateTime.Now.Date },
            ConnectionStringName, true);
    }
}