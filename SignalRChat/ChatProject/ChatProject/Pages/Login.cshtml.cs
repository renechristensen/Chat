using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace ChatProject.Pages.Shared
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public string brugernavn { get; set; }
        [BindProperty]
        public string kodeord { get; set; }
        public void OnPost()
        {
            Console.WriteLine("cheese");
            // skriv kode der tester om det er en eksisterende bruger her.
        }
    }
}
