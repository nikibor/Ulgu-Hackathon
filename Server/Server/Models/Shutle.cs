using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class Shutle
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Adress { set; get; }
        public DateTime Date { set; get; }
        public string Xpoint { set; get; }
        public string Ypoint { set; get; }
        public Shutle(int id,string name,string adres, string xpoint, string ypoint)
        {
            Id = id;
            Name = name;
            Adress = adres;
            //this.Date = Date;
            Xpoint = xpoint;
            Ypoint = ypoint;
        }
    }
}