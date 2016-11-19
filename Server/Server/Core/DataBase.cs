using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Server.Core
{
    public class DataBase
    {
        public static int ID { set; get; } = 2;
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
        public static SqlDataReader SelectAll()
        {
            SqlDataReader reader;
            SqlConnection connection = new SqlConnection(Connection);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Shutle]", connection);
            reader = command.ExecuteReader();
            connection.Close();
            return reader;
        }
    }
}