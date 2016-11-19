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
            string url= "http://iwannagohom.azurewebsites.net/Port/TestXml";
            XmlSerializer serializer = new XmlSerializer(typeof(MessageToServer));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, ServMes);
            string serializedXML = writer.ToString();
            var answer=POST(url, serializedXML);
            SendMessage(answer, Convert.ToInt32(chatId));
            //try
            //{
            //    string responseXml;
            //    var request = (HttpWebRequest)WebRequest.Create(url+ serializedXML);
            //    request.Method = "GET";
            //    var response = (HttpWebResponse)request.GetResponse();
            //    using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            //    {
            //        responseXml = stream.ReadToEnd();
            //        Console.WriteLine(responseXml);
            //    }
                
            //}
            //catch (Exception)
            //{
                
            //}

        }
        private string GET(string Url, string Data)//get запрос к серваку
        {
            try
            {
                WebRequest req = WebRequest.Create(Url + "?xml=" + Data);
                WebResponse resp = req.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader sr = new StreamReader(stream);
                string Out = sr.ReadToEnd();
                sr.Close();
                return Out;
            }
            catch (WebException webex)
            {
                return "Сорян, сервер упал";
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                    
                }
            }
        }

        private static string POST(string Url, string Data)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(Url);
            req.Method = "POST";
            req.Timeout = 100000;
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(Data);
            req.ContentLength = sentData.Length;
            System.IO.Stream sendStream = req.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            System.Net.WebResponse res = req.GetResponse();
            System.IO.Stream ReceiveStream = res.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(ReceiveStream, Encoding.UTF8);
            //Кодировка указывается в зависимости от кодировки ответа сервера
            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            string Out = String.Empty;
            while (count > 0)
            {
                String str = new String(read, 0, count);
                Out += str;
                count = sr.Read(read, 0, 256);
            }
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
