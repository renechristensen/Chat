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
        [BindProperty]
        public string Alias2 { get; set; } = "";

        public IActionResult OnPostTilbage()
        {
            return Redirect("/Oversigtsside");
        }

        public IActionResult OnPostTilchat()
        {
            HttpContext.Session.SetString("Alias", Alias2);
            Console.WriteLine(Alias2);
            return Redirect("/Chatside");
        }
    }
}
