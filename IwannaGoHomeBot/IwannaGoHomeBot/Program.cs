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
        static void Main(string[] args)
        {
            //TelegramRequest tr = new TelegramRequest();
            //tr.ResponseRecived += Tr_responseRecived;
            //tr.GetUpdates();
            //Thread thread = new Thread(tr.GetUpdates);
            //thread.IsBackground=true;
            //thread.Start();
            while(true)
            {
                testApiAsync();
            }

        }
        static async void testApiAsync()
        {
            var Bot = new Telegram.Bot.TelegramBotClient("270980713:AAHAh05xhXE3ULEMT6vozVh4JrrwRCryQBk");
            var me = await Bot.GetMeAsync();
            System.Console.WriteLine("Hello my name is " + me.FirstName);
        }

        private static void Tr_responseRecived(object sender, ParametrResponse e)
        {
            Console.WriteLine("{0}:{1} chatId{2}", e.name, e.message, e.chatID);
            TelegramRequest tr = new TelegramRequest();
            tr.SendMessage("Hi", Convert.ToInt32(e.chatID));
        }
        public delegate void Response(object sender, ParametrResponse e);

        public class ParametrResponse:EventArgs
        {
            public string name;
            public string message;
            public string chatID;
        }

        public class TelegramRequest
        {
            public string Token= "270980713:AAHAh05xhXE3ULEMT6vozVh4JrrwRCryQBk";
            int lastUpdateID = 0;

            public event Response ResponseRecived;

            ParametrResponse e = new ParametrResponse();

            string link = "https://api.telegram.org/bot";

            public void SendMessage(string message, int ChatID)
            {
                using (WebClient webClient = new WebClient())
                {
                    NameValueCollection pars = new NameValueCollection();
                    pars.Add("chat_id", ChatID.ToString());
                    pars.Add("text", message);
                    webClient.UploadValues(link + Token + "/sendMessage", pars);
                }
            }
            public void GetUpdates()
            {
                while (true)
                {
                    try
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
                                e.name = r["message"]["from"]["username"];
                                e.message = r["message"]["text"];
                                e.chatID = r["message"]["chat"]["id"];
                            }
                        }
                        ResponseRecived(this, e);
                    }
                    catch(Exception ex)
                    {
                        SendMessage("упало", Convert.ToInt32(e.chatID));
                    }
                }
            }
        }
    }
}
