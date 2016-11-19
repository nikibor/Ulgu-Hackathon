using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace SeoToolsMainApp.Core
{
    public class HttpProtocol
    {
        public string Url { set; get; }

        /// <summary>
        /// Отправка запроса на сервер через url
        /// </summary>
        /// <param name="url">Ссылка на сервер</param>
        /// <param name="method">Тип запроса(GET, PUSH, PUT, DELETE)</param>
        /// <param name="code">Кодировка</param>
        /// <returns>Ответ с сервера</returns>
        public static string TakeData(string url, string method, Encoding code)
        {
            try
            {
                string responseXml;
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                var response = (HttpWebResponse)request.GetResponse();
                using (StreamReader stream = new StreamReader(response.GetResponseStream(), encoding: code))
                {
                    responseXml = stream.ReadToEnd();
                }
                return responseXml;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string TakePOST(HttpRequestBase Request)
        {
            string value;
            using (System.IO.StreamReader SR = new System.IO.StreamReader(Request.InputStream))
            {
                value = SR.ReadToEnd();
            }
            return value;
        }

        /// <summary>
        /// Вывод всех заголовков сервера
        /// </summary>
        /// <param name="url">Адрес сервера</param>
        /// <returns>Заголовки HTTP</returns>
        public static string TakeHeaders(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            var response = (HttpWebResponse)request.GetResponse();
            return response.Headers.ToString();
        }
        /// <summary>
        /// Получение данных через прямой запрос на сервер
        /// </summary>
        /// <param name="url">Адрес сервера</param>
        /// <param name="method">Тип запроса(GET, PUSH, PUT, DELETE)</param>
        /// <param name="contentType">Тип отправляемого сообщения</param>
        /// <param name="data">Передаваемое сообщение</param>
        /// <returns>Текстовое сообщение полученное от сервера</returns>
        public static string TakeData(string url, string method, string contentType, string data)
        {
            var request = WebRequest.Create(url);
            request.Method = method;
            request.ContentType = contentType;
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(data);
            request.ContentLength = sentData.Length;
            Stream sentStream = request.GetRequestStream();
            sentStream.Write(sentData, 0, sentData.Length);
            sentStream.Close();
            WebResponse response = request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(receiveStream, Encoding.UTF8);
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

        
        /// <summary>
        /// Обрезка адреса до его домена
        /// </summary>
        /// <param name="url">Ссылка</param>
        /// <returns>Домен</returns>
        public static string CreateDomen(string url)
        {
            url = url.Remove(0, url.IndexOf('/') + 2);
            if (url.StartsWith("www."))
                url = url.Remove(0, 4);
            return url;
        }

        /// <summary>
        /// Проверка строки url на её валидность
        /// </summary>
        /// <returns>true, если строка типа url или false, если нет</returns>
        public static bool IsUrl(string urlAdress)
        {
            string pattern = @"(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";
            return new Regex(pattern).IsMatch(urlAdress);
        }

        /// <summary>
        /// Проверка на наличение заголовка с протоколом
        /// </summary>
        /// <param name="url">Ссылка</param>
        /// <returns>Дополненную или первоначальную ссылку</returns>
        public static string HttpPrefixCheck(string url)
        {
            if (!(url.StartsWith("http://") || url.StartsWith("https://")))
                url = $"http://{url}";
            return url;
        }
        /// <summary>
        /// Проверка на существование URL
        /// </summary>
        /// <param name="url">Адрес сайта</param>
        /// <returns>true - существует, false - противоположно</returns>
        public static bool ExistUrl(string url)
        {
            var response = TakeData(url, "GET", Encoding.UTF8);
            return (response != null);
        }
    }
}