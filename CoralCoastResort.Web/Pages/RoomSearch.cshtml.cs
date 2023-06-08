using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoralCoastResort.Web.Pages;

public class RoomSearch : PageModel
{
    [DataType(DataType.Date)]
    [BindProperty]
    public DateTime StartDate { get; set; } = DateTime.Now;

    [DataType(DataType.Date)]
    [BindProperty]
    public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
    
    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        return Page();
    }
}