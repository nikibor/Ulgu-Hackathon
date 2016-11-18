using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class PortController : Controller
    {
        // GET: Port
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult CreateUser()
        //{
        //    return "asd";
        //}
    }
}