using ChatProject.Classerne;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR.Client;


namespace ChatProject.Pages
{
    public class ChatsideModel : PageModel
    {
        [BindProperty]
        public List<Besked> beskederne { get; set; } = new();
        [BindProperty]
        public Dictionary<string, string> kontoerne { get; set; } = new();

        public static SRClient client = new SRClient();
        public IActionResult OnGet()
        {
            client.connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Console.WriteLine(message);
            });

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
            string message = $"SELECT * FROM (Select * FROM Besked WHERE ChatrumID = {Convert.ToInt32(HttpContext.Session.GetString("ChatrumID"))} ORDER BY BeskedID Desc Limit 50) AS sub ORDER BY BeskedID Asc;";
            beskederne = ConMysql.GetBeskeder(message);
            foreach(Besked besked in beskederne)
            {
                string beskedIDD = Convert.ToString(besked.BeskedID);

                if (!kontoerne.ContainsKey(beskedIDD)) {
                    message = $"SELECT * FROM Konto WHERE KontoID = {besked.KontoID};";
                    Konto konto = ConMysql.GetKonto(message);
                    kontoerne.Add(beskedIDD, konto.Alias);
                }
            }
            return beskederne;
        }

        // Message typed in the reply box
        [BindProperty]
        public string besked { get; set; } = "";
        
        public void Send()
        {
             client.connection.InvokeAsync("SendMessage", "username", "Besked");
        }
        public void OnPost()
        {
            if (besked != null)
            {
                int ChatrumID = Convert.ToInt32(HttpContext.Session.GetString("ChatrumID"));
                int KontoID = Convert.ToInt32(HttpContext.Session.GetString("KontoID"));
                Send();
                string message = $"INSERT INTO Besked(Text, ChatrumID, KontoID) VALUES('{besked}', {HttpContext.Session.GetString("ChatrumID")}, {HttpContext.Session.GetString("KontoID")});";
                //Console.WriteLine(message);
                ConMysql.SendSqlQuery(message);
                GetBeskeder();
            }
        }
    }
}
