using Server.Core;
using Server.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

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
        public string TakeTelegramData()
        {
            try
            {
                string xml = HttpProtocol.TakePOST(Request);
                var serializer = new XmlSerializer(typeof(MessageToServer));
                MessageToServer result;
                using (TextReader reader = new StringReader(xml))
                {
                    result = (MessageToServer)serializer.Deserialize(reader);
                }
                return result.First_name + '\n' + result.Street;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }        
    }
}