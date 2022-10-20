using ChatProject.Classerne;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata;
using System.Security.Policy;

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
        [BindProperty]
        public string? Addresse { get; set; }
        [BindProperty]
        public string? Postnummer { get; set; }
        [BindProperty]
        public string? Byen { get; set; }

        public IActionResult OnPost()
        {
            Console.WriteLine("ceehce");
            try
            {
                if(PersonligBeskrivelse is null)
                {
                    //PersonligBeskrivelse = "";
                }

                string message = $"INSERT INTO Kunde(Navn, Efternavn, Telefonnummer, Email, Personbeskrivelse) VALUES('{Navn}', '{Efternavn}', '{Telefonnummer}', '{Email}', '{PersonligBeskrivelse}');";
                ConMysql.SendSqlQuery(message);
                int KundeID= ConMysql.GetID("SELECT MAX(KundeID) FROM Kunde;");
                message = $"INSERT INTO Bopæl(Addresse, Postnummer, Byen, KundeID) VALUES('{Addresse}', '{Postnummer}', '{Byen}', '{KundeID}');";
                ConMysql.SendSqlQuery(message);
                message = $"INSERT INTO Konto(Kodeord, Brugernavn, Alias, KundeID) VALUES('{Kodeord}', '{Brugernavn}', '{Brugernavn}','{KundeID}');";
                ConMysql.SendSqlQuery(message);
                return Redirect("/Login");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Redirect("/Register");
        }
    }
}
