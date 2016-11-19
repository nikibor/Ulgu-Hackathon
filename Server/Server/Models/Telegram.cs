using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class Telegram
    {
        public int TelegramId { set; get; }
        public int ID { set; get; }
        public string FirstName { set; get; }
        public string Username { set; get; }
    }
}