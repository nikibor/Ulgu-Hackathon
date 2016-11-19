using SeoToolsMainApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace Server.Core
{
    public class GeoLoactionYandex
    {
        public string Street { set; get; }
        public string NumOfHouse { set; get; }
        public string XPoint { set; get; }
        public string YPoint { set; get; }
        public GeoLoactionYandex(string street,string numOfHouse)
        {
            Street = street;
            NumOfHouse = numOfHouse;
            string yandexServer = "https://geocode-maps.yandex.ru/1.x/?geocode=";
            yandexServer = $"{yandexServer}Россия+Ульяновск+{Street}+{NumOfHouse}";
            TakePoints(HttpProtocol.TakeData(yandexServer, "GET", Encoding.UTF8));
        }
        public void TakePoints(string responseXml)
        {
            string Points = "";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseXml);
            if (doc.DocumentElement != null)
                foreach (XmlNode noda in doc.DocumentElement)
                {
                    XmlNodeList xnList = doc.SelectNodes("/featureMember/Point ");
                    foreach (XmlNode xn in xnList)
                    {
                        Points = xn["pos"]?.InnerText;
                    }
                }

        }
    }
}