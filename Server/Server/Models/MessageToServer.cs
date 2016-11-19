using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class MessageToServer
    {
        public string UserName { set; get; }
        public string First_name { set; get; }
        public string Last_name { set; get; }
        public string Street { set; get; }
        public string NumberHouse { set; get; }
        public string ChatID { set; get; }
    }
}