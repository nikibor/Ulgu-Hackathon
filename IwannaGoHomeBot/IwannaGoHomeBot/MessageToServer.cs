using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IwannaGoHomeBot
{
    public class MessageToServer
    {
        private string username;
        private string first_name;
        private string last_name;
        private string street;
        private string numberHouse;
        private string chatID;

        public string UserName
        { get; set; }
        public string First_name
        { get; set; }
        public string Last_name
        { get; set; }
        public string Street
        { get; set; }
        public string NumberHouse
        { get; set; }
        public string ChatID
        { get; set; }

    }
}
