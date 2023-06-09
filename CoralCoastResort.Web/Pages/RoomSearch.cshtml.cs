using System.ComponentModel.DataAnnotations;
using DataAccessLibrary.Data;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoralCoastResort.Web.Pages;

public class RoomSearch : PageModel
{
    private readonly IDatabaseData _db;

    public RoomSearch(IDatabaseData db)
    {
        _db = db;
    }

    [DataType(DataType.Date)]
    [BindProperty(SupportsGet = true)]
    public DateTime StartDate { get; set; } = DateTime.Now;

    [DataType(DataType.Date)]
    [BindProperty(SupportsGet = true)]
    public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

    [BindProperty(SupportsGet = true)] 
    public bool SearchComplete { get; set; } = false;

    public List<RoomTypesDto> AvailableRoomTypes { get; set; }

    public void OnGet()
    {
        if (SearchComplete)
        {
            AvailableRoomTypes = _db.GetAvailableRoomTypes(StartDate, EndDate);
        }
    }

    public IActionResult OnPost()
    {
        return RedirectToPage(new { SearchComplete = true, StartDate, EndDate });
    }
}