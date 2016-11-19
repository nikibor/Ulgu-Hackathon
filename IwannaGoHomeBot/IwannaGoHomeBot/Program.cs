using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using SimpleJSON;
using System.Threading;
using System.Collections.Specialized;

namespace IwannaGoHomeBot
{
    class Program
    {
        static public string Token= "239159484:AAFJYqTigujbYaw47Dm0x22PUYQbrIJqC68";
        static void Main(string[] args)
        {
            //TelegramRequest tr = new TelegramRequest(Token);
            //tr.ResponseRecived += Tr_responseRecived;
            //tr.GetUpdates();
            //Thread thread = new Thread(tr.GetUpdates);
            //thread.IsBackground = true;
            //thread.Start();
            //Console.ReadKey();
            PoiskVGlubinu poisk = new PoiskVGlubinu();
            poisk.startFind();
        }

        private static void Tr_responseRecived(object sender, ParametrResponse e)
        {
            Methods met = new Methods(Token);
            Console.WriteLine("UserName-{0} FirstName- {1} SecondName-{2}:{3} chatId{4}", e.username,e.first_name,e.last_name, e.message, e.chatID);
            met.SendMessageToServer(e.username, e.first_name, e.last_name, e.message, e.chatID);
            met.SendMessage("Я работаю!", Convert.ToInt32(e.chatID));
            met.SendSticker(Convert.ToInt32(e.chatID), "BQADAgADHAADyIsGAAFzjQavel2uswI");

        }
        public delegate void Response(object sender, ParametrResponse e);

        public class ParametrResponse:EventArgs
        {
            public string username;
            public string message;
            public string chatID;
            public string first_name;
            public string last_name;
        }

        public class TelegramRequest
        {
            string Token;
            public TelegramRequest(string Token)
            {
                this.Token = Token;
            }
            int lastUpdateID = 0;

            public event Response ResponseRecived;

            ParametrResponse e = new ParametrResponse();

            string link = "https://api.telegram.org/bot";

            public void GetUpdates()
            {
                while (true)
                {
                        using (WebClient webClient = new WebClient())
                        {
                            string response = webClient.DownloadString(link + Token + "/getUpdates?offset=" + (lastUpdateID + 1));

                            if (response.Length <= 23)
                                continue;
                            var N = JSON.Parse(response);
                            foreach (JSONNode r in N["result"].AsArray)
                            {
                                lastUpdateID = r["update_id"].AsInt;
                                e.username = r["message"]["from"]["username"];
                                e.message = r["message"]["text"];
                                e.chatID = r["message"]["chat"]["id"];
                                e.first_name = r["message"]["from"]["first_name"];
                                e.last_name = r["message"]["from"]["last_name"];
                            }
                        }
                        ResponseRecived(this, e);
                    }
                }
            
        }
    }
}
