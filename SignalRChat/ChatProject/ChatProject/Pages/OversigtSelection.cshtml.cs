using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatProject.Pages
{
    public class OversigtSelectionModel : PageModel
    {
        public IActionResult OnGet()
        {
            Alias = HttpContext.Session.GetString("SessionsBrugernavn"); ;
            if (String.IsNullOrWhiteSpace(HttpContext.Session.GetString("SessionsBrugernavn")))
            {
                return Redirect("/Login");
            }
            else
            {
                return Page();
            }
        }

        [BindProperty]
        public string? Alias { get; set; }

        public IActionResult OnPostTilbage()
        {
            Console.WriteLine(Alias);
            return Redirect("/Oversigtsside");
        }

        public IActionResult OnPostTilchat()
        {
            Console.WriteLine("TILCHAT");
            return Redirect("/Oversigtsside");
        }
    }
}
