using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Server.Models
{    
    [XmlRoot("MessageToServer")]
    public class MessageToServer
    {
        [XmlElement("UserName")]
        public string UserName { get; set; }
        [XmlElement("First_name")]
        public string First_name { get; set; }
        [XmlElement("Last_name")]
        public string Last_name { get; set; }
        [XmlElement("Street")]
        public string Street { get; set; }
        [XmlElement("NumberHouse")]
        public string NumberHouse { get; set; }
        [XmlElement("ChatID")]
        public string ChatID { get; set; }
            
    }
}