using MySql.Data.MySqlClient;
namespace ChatProject.Classes
{
    public class ConMysql
    {
        static readonly string cs = @"server=localhost;userid=dbuser;password=s$cret;database=testdb";
        static readonly MySqlConnection Connect = new MySqlConnection(cs);

        public void SendSqlQuery(string Message)
        {
            Connect.Open();
            MySqlCommand Cmd = new MySqlCommand(Message, Connect);

        }

    }
}