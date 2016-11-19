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
        public string Testxml(string xml)
        {
            if (xml == null)
                return "Строка не передалась";
            else if (xml.Length == 0)
                return "Строка пустая";
            else return "Всё ок";
        }
        //[HttpPost]
        //public string TakeXml()
        //{
        //    string responseXml = "";
        //    HttpWebResponse response = new HttpWebResponse();
        //    using (StreamReader stream = new StreamReader(response.GetResponseStream(), encoding: code))
        //    {
        //        responseXml = stream.ReadToEnd();
        //    }
        //    return responseXml;
        //}
    }
}