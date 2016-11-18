using Server.Core;
using System;
using System.Collections.Generic;
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
        public ActionResult Add()
        {
            return View();
        }
        //public ActionResult Add(int TelegramId,int ID,string FirstName,string Username)
        //{
        //    DataBase.Querry($@"INSERT INTO TABLE TelegramUsers (IdTelegram, FirstName, Username, Id) VALUES ");

        //}


    }
}