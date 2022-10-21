using ChatProject.Classerne;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatProject.Pages
{
    public class ChatsideModel : PageModel
    {
        public List<Besked> beskederne = new();
        public IActionResult OnGet()
        {
            GetBeskeder();
            if (String.IsNullOrWhiteSpace(HttpContext.Session.GetString("SessionsBrugernavn")))
            {
                return Redirect("/Login");
            }
            else
            {
                return Page();
            }
        }

        public List<Besked> GetBeskeder()
        {
            string message = $"SELECT * FROM Besked WHERE ChatrumID = {Convert.ToInt32(HttpContext.Session.GetString("ChatrumID"))}ORDER BY BeskedID Limit 2;";
            Console.WriteLine(message);
            beskederne = ConMysql.GetBeskeder(message);
            foreach(Besked besked in beskederne)
            {
                Console.WriteLine(besked.Text);
            }
            return beskederne;
        }
        [BindProperty]
        public string besked { get; set; } = "";

        public void OnPost()
        {
           
            int ChatrumID = Convert.ToInt32(HttpContext.Session.GetString("ChatrumID"));
            int KontoID = Convert.ToInt32(HttpContext.Session.GetString("KontoID"));
            string message = $"INSERT INTO Besked(Text, ChatrumID, KontoID) VALUES('{besked}', {HttpContext.Session.GetString("ChatrumID")}, {HttpContext.Session.GetString("KontoID")});";
            Console.WriteLine(message);
            ConMysql.SendSqlQuery(message);
            GetBeskeder();
        }
    }
}
