using Server.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class TelegramController : Controller
    {
        // GET: Telegram
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public string Add()
        {
            try
            {
                string Connection = @"Server=tcp:nikitaborgolov.database.windows.net,1433;Initial Catalog=DataBase;Persist Security Info=False;User ID=nborgolov96;Password=Nikita207968811;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                SqlConnection connection = new SqlConnection(Connection);
                connection.Open();
                return "ВСё ХоРОшО";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public ActionResult Add(int TelegramId, int ID, string FirstName, string Username)
        {
            //if()
            DataBase.Querry($@"INSERT INTO TABLE TelegramUsers (IdTelegram, FirstName, Username, Id) VALUES ('{TelegramId}','{ID}','{FirstName}','{Username}')");

            if (DataBase.Select("SELECT * FROM TelegramUsers") == 1)
            {
                return View("Good");
            }
            else return View("Bad");
        }
    }
}