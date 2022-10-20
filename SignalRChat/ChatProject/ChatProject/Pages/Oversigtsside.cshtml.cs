using ChatProject.Classerne;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatProject.Pages
{
    public class OversigtssideModel : PageModel
    {
        public IActionResult OnGet()
        {
            Console.WriteLine(HttpContext.Session.GetString("SessionsBrugernavn"));
            if(String.IsNullOrWhiteSpace(HttpContext.Session.GetString("SessionsBrugernavn")))
            {
                return Redirect("/Login");
            }
            else
            {
                return Page();
            }
        }
    }
}
