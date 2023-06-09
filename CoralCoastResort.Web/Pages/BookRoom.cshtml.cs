using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoralCoastResort.Web.Pages;

public class BookRoom : PageModel
{
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
    
    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        return RedirectToPage("./Index");
    }
}