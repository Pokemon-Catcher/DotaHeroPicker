﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

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
            //Debug.WriteLine(request.Headers);
            return request;
        }
        public static string GetPage(HttpWebRequest request)
        {
            string result="Error";
            using(HttpWebResponse response = (HttpWebResponse) request.GetResponse()){
                //foreach (string i in response.Headers)
                //{
                //    Debug.WriteLine(i+":"+response.Headers[i]);
                //}
                using(Stream dataStream = response.GetResponseStream())
                {
                    Encoding encoding = Encoding.GetEncoding(response.CharacterSet);
                    using (StreamReader reader = new StreamReader(dataStream, encoding)){
                        result = reader.ReadToEnd();
                        //Debug.Write(result);
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

        public static void GetHeroRoles(string heroName, HashSet<HeroRoles> result)
        {
                HttpWebRequest request = GetRequest("https://dotabuff.com/heroes/" + heroName.ToLower());
                string page = GetPage(request);
                Match match = Regex.Match(page, @"<title>(.)+</title>");
                string rolesString = match.Value;
                rolesString = Regex.Replace(rolesString, @"<title>", "");
                rolesString = Regex.Replace(rolesString, @"\s-\sDOTABUFF\s-\sDota\s2\sStats</title>", "");
                rolesString = Regex.Replace(rolesString, heroName + " - ", "");
                string[] roles = Regex.Split(rolesString, @",\s");
                foreach (string role in roles)
                {
                    //Debug.WriteLine(heroName+" - "+HeroInfo.ToRole(role.ToLower()));
                    result.Add(HeroInfo.ToRole(role.ToLower()));
                    ;
                }
        }

        public static void GetHeroCounters(string heroName, Hashtable results)
        {
            HttpWebRequest request = GetRequest("https://dotabuff.com/heroes/"+heroName.ToLower()+"/counters");
            string page = GetPage(request);
            Match begin = Regex.Match(page, @"Matchups");
            Debug.WriteLine(heroName+" "+begin.Success+" "+begin.Index);
            page=page.Substring(begin.Index,page.Length-begin.Index);
            MatchCollection matches = Regex.Matches(page, @"data-value=""[A-z\s]+""");
            foreach (Match match in matches)
            {
                //Debug.WriteLine(match.Value);
                float[] info = new float[3];
                string matchString = match.Value;
                matchString = Regex.Replace(matchString, @"data-value=""","");
                matchString = Regex.Replace(matchString, @"""", "");
                //Debug.WriteLine(matchString);
                string newPage = page.Substring(match.Index-5, page.Length - match.Index);
                MatchCollection matchesInfo = Regex.Matches(newPage, @"data-value=""-?[0-9]+\.?[0-9]*""");
                int i = 0;
                foreach (Match matchInfo in matchesInfo)
                {
                    string infoString = matchInfo.Value;
                    infoString = Regex.Replace(infoString, @"data-value=""", "");
                    infoString = Regex.Replace(infoString, @"""", "");
                    infoString = Regex.Replace(infoString, @"\.",",");
                    if (i > 2) break;
                    if (!float.TryParse(infoString, out info[i]))
                    {
                        info[i] = 0;
                        Debug.WriteLine("Float parsing has failed"+i.ToString());
                    }


                    //Debug.WriteLine(matchString + " " + i.ToString() + " " + infoString);
                    i++;
                }

                results.Add(matchString.ToLower(),info);
            }
        }
    }
}
