using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatProject.Pages
{
    public class RegisterModel : PageModel
    {
        public void OnGet()
        {
        }
        [BindProperty]
        public string? Navn { get; set; }
        [BindProperty]
        public string? Efternavn { get; set; }
        [BindProperty]
        public string? Email { get; set; }
        [BindProperty]
        public string? Telefonnummer { get; set; }
        [BindProperty]
        public string? PersonligBeskrivelse { get; set; }
        [BindProperty]
        public string? Brugernavn { get; set; }
        [BindProperty]
        public string? Kodeord { get; set; }
        [BindProperty]
        public string? Gkodeord { get; set; }

        public void OnPost()
        {

        }
    }
}
