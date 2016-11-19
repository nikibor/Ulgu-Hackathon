using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Server.Core
{
    public class DataBase
    {
        private static string Connection = @"Server=tcp:nikitaborgolov.database.windows.net,1433;Initial Catalog=DataBase;Persist Security Info=False;User ID=nborgolov96;Password=Nikita207968811;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static void Querry(string querry)
        {
            SqlConnection connection = new SqlConnection(Connection);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(querry, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
        }
        public static int Select(string querry)
        {
            SqlConnection connection = new SqlConnection(Connection);
            try
            {
                SqlCommand command = new SqlCommand(querry, connection);
                var a = command.ExecuteNonQuery();
                return a;
            }
            catch (Exception)
            {
                connection.Close();
                return -1;
            }
        }
    }
}