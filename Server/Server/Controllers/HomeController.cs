using Server.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<string> Rows = new List<string>();
            var reader = DataBase.SelectAll();
            foreach(var row in reader)
            {
                Rows.Add(row.ToString());
            }
            return View();
        }
    }
}