using SeoToolsMainApp.Core;
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
                GeoLoactionYandex yandex = new GeoLoactionYandex(result.Street, result.NumberHouse);
                DataBase.Querry($"INSERT INTO [dbo].[Shutle] ([Id], [Name], [Adress], [Date], [Xpoint], [Ypoint]) VALUES ({DataBase.ID++}, '{result.First_name}', '{result.Street} {result.NumberHouse}', '{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}', '{yandex.XPoint}', '{yandex.YPoint}')");
                return $"{result.First_name}, Ваш запрос обработан и добавлен";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }        
    }
}