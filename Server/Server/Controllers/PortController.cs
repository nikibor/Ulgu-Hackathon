using Server.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        
        [HttpGet]
        public string TestXml(string xml)
        {
            if (xml == null)
                return "Строка не передалась";
            else if (xml.Length == 0)
                return "Строка пустая";
            else return "Всё ок";
        }
        [HttpPost]
        public string Testxml()
        {
            string value;
            using (System.IO.StreamReader SR = new System.IO.StreamReader(Request.InputStream))
            {
                value = SR.ReadToEnd();
            }
            return value;
        }
        //[HttpPost]
        //public HttpResponse TakeXml()
        //{
            
        //}
    }
}