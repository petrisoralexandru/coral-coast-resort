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
    public List<RoomTypesModel> GetAvailableRoomTypes(DateOnly startDate, DateOnly endDate)
    {
        return _db.LoadData<RoomTypesModel, dynamic>("dbo.RoomTypes_GetAvailableTypes", new { startDate, endDate },
            ConnectionStringName, true);
    }
}