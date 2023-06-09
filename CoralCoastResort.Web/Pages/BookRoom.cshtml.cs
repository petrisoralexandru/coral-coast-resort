using DataAccessLibrary.Data;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoralCoastResort.Web.Pages;

public class BookRoom : PageModel
{
    private readonly IDatabaseData _db;

    public BookRoom(IDatabaseData db)
    {
        _db = db;
    }

    [BindProperty]
    public string? FirstName { get; set; }

    [BindProperty]
    public string? LastName { get; set; }

    [BindProperty(SupportsGet = true)]
    public int RoomTypeId { get; set; }

    [BindProperty(SupportsGet = true)]
    public DateTime StartDate { get; set; }

    [BindProperty(SupportsGet = true)]
    public DateTime EndDate { get; set; }

    public RoomTypesDto? RoomType { get; set; }
    
    public void OnGet()
    {
        if (RoomTypeId > 0)
        {
            RoomType = _db.GetRoomTypeById(RoomTypeId);
        }
    }

    public IActionResult OnPost()
    {
        _db.BookGuest(FirstName, LastName, StartDate, EndDate, RoomTypeId);
        return RedirectToPage("./Index");
    }
}