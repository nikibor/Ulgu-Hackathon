using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class PortController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        public string TestXml(string xml)
        {
            if (xml == null)
                return "Строка не передалась";
            else if (xml.Length == 0)
                return "Строка пустая";
            else return "Всё ок";
        }
    }
}