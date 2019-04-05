using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Text;

namespace Hero.NetWorking
{
    class Net
    {
        public static HttpWebRequest GetRequest(string url)
        {
                    Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Method = "GET";
            request.KeepAlive = true;
            request.AllowAutoRedirect = true;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.86 Safari/537.36";
            request.Headers.Add("accept-language: ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");
            request.Headers.Add("accept-encoding: gzip, deflate, br");
            request.Headers.Add("scheme","https");
            request.Headers.Add("authority","www.dotabuff.com");
            request.Headers.Add("Cache-Control: no-cache");
            request.Headers.Add("x-compress: null");
            request.Headers.Add("upgrade-insecure-requests: 1");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            Debug.WriteLine(request.Headers);
            return request;
        }
        public static string GetPage(HttpWebRequest request)
        {
            string result="Error";
            using(HttpWebResponse response = (HttpWebResponse) request.GetResponse()){
                foreach (string i in response.Headers)
                {
                    Debug.WriteLine(i+":"+response.Headers[i]);
                }
                using(Stream dataStream = response.GetResponseStream())
                {
                    Encoding encoding = Encoding.GetEncoding(response.CharacterSet);
                    using (StreamReader reader = new StreamReader(dataStream, encoding)){
                        result = reader.ReadToEnd();
                        Debug.Write(result);
                    }
                }   
            }
            return result;
        }

        public static Image GetImage(string url)
        {
            HttpWebRequest request = GetRequest(url);
            Image result;
            using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
            {
                result = Image.FromStream(response.GetResponseStream());
            }
            return result;
        }

        public static void GetHeroes(string page, HeroInfo[] results)
        {
            
        }

        public static List<string> GetHeroesNameList(string page)
        {
            List<string> result = new List<string>();
            MatchCollection matches = Regex.Matches(page, @"<div class=""name"">\w*</div>");
            foreach (Match match in matches)
            {
                string name = match.Value.Substring(18, match.Value.Length - 24);
                result.Add(name);
                Debug.WriteLine(name);
            }
            return result;
        }
    }
}
