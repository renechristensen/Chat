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
            if(String.IsNullOrWhiteSpace(HttpContext.Session.GetString("SessionsBrugernavn")))
            {
                return Redirect("/Login");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPostView(string id)
        {
            Console.WriteLine($"Du har valgt id nr {id} ");
            HttpContext.Session.SetString("ChatrumID", id);
            return Redirect("/OversigtSelection");
        }
    }
}
