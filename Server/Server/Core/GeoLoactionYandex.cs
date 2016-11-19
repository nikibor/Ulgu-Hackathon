using Newtonsoft.Json.Linq;
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
            string yandexServer = "https://geocode-maps.yandex.ru/1.x/?format=json&geocode=";
            yandexServer = $"{yandexServer}Россия+Ульяновск+{Street}+{NumOfHouse}";
            TakePoints(HttpProtocol.TakeData(yandexServer, "GET", Encoding.UTF8));
        }
        public void TakePoints(string json)
        {
            string res = "";
            JObject jsonFile = JObject.Parse(json);
            res = jsonFile["response"]["GeoObjectCollection"]["featureMember"][0]["GeoObject"]["Point"]["pos"].ToString();
            var points = res.Split(' ');
            XPoint = points[1];
            YPoint = points[0];
        }
    }
}