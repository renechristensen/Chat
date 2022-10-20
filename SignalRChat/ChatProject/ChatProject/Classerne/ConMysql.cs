using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace ChatProject.Classerne
{
    public static class ConMysql
    {
        static readonly string cs = @"Server=mysql90.unoeuro.com;Port=3306;Database=christensenprogrammering_dk_db;User=christensenprogrammering_dk;pwd=QHA49qxp";
        static readonly MySqlConnection Connect = new(cs);

        public static void SendSqlQuery(string Message)
        {

            Connect.Open();
            try
            {
                MySqlCommand Cmd = new(Message, Connect);
                MySqlDataReader reader = Cmd.ExecuteReader();
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Connect.Close();
        }
        public static int GetID(string query)
        {
            int ID = -1;
            Connect.Open();
            try
            {
                MySqlCommand Cmd = new(query, Connect);
                MySqlDataReader reader = Cmd.ExecuteReader();

                while (reader.Read())
                {
                    ID=Convert.ToInt32(reader.GetString(0));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Connect.Close();
            return ID;
        }

        public static bool CheckLogin(string Message)
        {

            Connect.Open();
            try
            {
                MySqlCommand Cmd = new(Message, Connect);
                MySqlDataReader reader = Cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                    if(Convert.ToInt32(reader.GetString(0)) == 1)
                    {
                        Connect.Close();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Connect.Close();
            }
            Connect.Close();
            return false;
        }
    }
}