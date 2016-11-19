using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Core
{
    public class HttpProtocol
    {
        public static string TakePOST(HttpRequestBase Request)
        {
            string value;
            using (System.IO.StreamReader SR = new System.IO.StreamReader(Request.InputStream))
            {
                value = SR.ReadToEnd();
            }
            return value;
        }
    }
}