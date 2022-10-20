using ChatProject.Classerne;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlX.XDevAPI;
using System.ComponentModel;

namespace ChatProject.Pages.Shared
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
            
        }

        [BindProperty]
        public string brugernavn { get; set; } = "";
        [BindProperty]
        public string? kodeord { get; set; }
        [TempData]
        public string fejlbesked { get; set; } = "";
        public IActionResult OnPost()
        {
           
            Console.WriteLine("cheese");
            string message = $"SELECT EXISTS(SELECT * FROM Konto WHERE Brugernavn = '{brugernavn}' AND Kodeord = '{kodeord}')";
            if (ConMysql.CheckLogin(message))
            { 
                HttpContext.Session.SetString(Sessionsvariabler.SessionsBrugernavn, brugernavn);
                return Redirect("/Oversigtsside");
            }

            string? s = HttpContext.Session.GetString(Sessionsvariabler.SessionsBrugernavn);
            fejlbesked = $"Login fejlede {s} er ikke et korrekt brugernavn eller kodeordet er forkert";
            return Redirect("/Login");
        }
    }
}
