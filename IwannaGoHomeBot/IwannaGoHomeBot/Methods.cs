using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Specialized;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace IwannaGoHomeBot
{
    class Methods
    {
        #region BotApi
        string link = "https://api.telegram.org/bot";
        string Token;
        public Methods(string Token)
        {
            this.Token = Token;
        }
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
        public void SendSticker(int chatID, string IDsticker)
        {
            using (WebClient webClient = new WebClient())
            {
                NameValueCollection pars = new NameValueCollection();
                pars.Add("chat_id", chatID.ToString());
                pars.Add("sticker", IDsticker);
                webClient.UploadValues("https://api.telegram.org/bot" + Token + "/sendSticker", pars);
            }
        }
        #endregion

        #region ServerCooperation
        public void SendMessageToServer(string username, string first_name, string last_name, string message, string chatId)
        {
            MessageToServer ServMes = new MessageToServer();
            ServMes.UserName = username;
            ServMes.First_name = first_name;
            ServMes.Last_name = last_name;
            ServMes.ChatID = chatId;
            Parse(ref ServMes, message);
            string url= "http://iwannagohom.azurewebsites.net/Port/TestXml?xml=";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    Console.WriteLine("Всё норм.");
            //}
            //else if (response.StatusCode == HttpStatusCode.NotFound)
            //{
            //    Console.WriteLine("Такой страницы нет.");
            //}
            //response.Close();
            GET(url, "rdyeyer");
            try
            {
                string responseXml;
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                var response = (HttpWebResponse)request.GetResponse();
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    responseXml = stream.ReadToEnd();
                }
                
            }
            catch (Exception)
            {
                
            }

            //    XmlSerializer serializer = new XmlSerializer(typeof(MessageToServer)); 
            //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //    request.Method = "GET";
            //    request.ContentType = "text/xml";
            //StreamWriter sw = new StreamWriter(request.GetRequestStream());
            //sw.Write("sdgsdgwer");
            //sw.Close();
            //XmlTextWriter writer = new XmlTextWriter(request.GetRequestStream(), Encoding.UTF8);
            //serializer.Serialize(writer, ServMes);
            //writer.Close();

            //try
            //{
            //    string responseXml;
            //    var request = (HttpWebRequest)WebRequest.Create(url);
            //    request.Method = method;
            //    var response = (HttpWebResponse)request.GetResponse();
            //    using (StreamReader stream = new StreamReader(response.GetResponseStream(), encoding: code))
            //    {
            //        responseXml = stream.ReadToEnd();
            //    }
            //    return responseXml;
            ////}
            //catch (Exception)
            //{
            //    return null;
            //}

        }
        private string GET(string Url, string Data)
        {
            WebRequest req = WebRequest.Create(Url + "?xml=" + Data);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }

        public void Parse(ref MessageToServer ServMes,string message)//Парсит сообщение для бота
        {

            if (message.Contains("Улица") || message.Contains("улица"))
            {
                if (message.Contains("Дом"))
                {
                    ServMes.Street = message.Substring(5, message.IndexOfAny("Дом".ToArray())-5).Trim("[-.?!)(,:]".ToArray());
                    ServMes.NumberHouse = message.Substring(message.IndexOfAny("Дом".ToArray())+1).Trim("[-.?!)(,:]".ToArray());
                }
                if (message.Contains("дом"))
                {
                    ServMes.Street = message.Substring(5, message.IndexOfAny("дом".ToArray())-5).Trim(" [-.?!)(,:]".ToArray());
                    ServMes.NumberHouse = message.Substring(message.LastIndexOfAny("дом".ToArray())+1).Trim(" [-.?!)(,:]".ToArray());
                }
            }
        }
        #endregion
    }
}
