using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Hero.NetWorking
{
    class Net
    {
        public static string GetPage(string url)
        {
            string result;
            WebRequest request = WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            result = reader.ReadToEnd();
            return result;
        }
    }
}
