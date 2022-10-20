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
           
            string message = $"SELECT EXISTS(SELECT * FROM Konto WHERE Brugernavn = '{brugernavn}' AND Kodeord = '{kodeord}')";
            if (ConMysql.CheckLogin(message))
            {
                fejlbesked = "login valideret";
                HttpContext.Session.SetString("SessionsBrugernavn", brugernavn);
                return Redirect("/Oversigtsside");
            }
            fejlbesked = $"Login fejlede {brugernavn} er ikke et korrekt brugernavn eller kodeordet er forkert";
            return Redirect("/Login");
        }
    }
}
