using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Server.Core
{
    public class DataBase
    {
        private static string Connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nik_borgolov\Documents\Hackathon.mdf;Integrated Security=True;Connect Timeout=30";
        public static void Querry(string querry)
        {
            SqlConnection connection = new SqlConnection(Connection);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(querry, connection);
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }

    }
}