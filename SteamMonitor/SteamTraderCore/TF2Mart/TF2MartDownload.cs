using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace SteamMonitor.SteamTraderCore.TF2Mart
{
    public class Tf2MartDownload
    {
        public const string TF2_MART_POST_PARAMS =
            "filters=%7B%22currency%22%3A%22credits%22%2C%22page" +
            "%22%3A%7B%22sort%22%3A%7B%22type%22%3A%22type%22%2C" +
            "%22dir%22%3A%22asc%22%7D%2C%22direction%22%3A1%2C%2" +
            "2size%22%3A50%2C%22defindex%22%3A{0}%2C%22quality%2" +
            "2%3A{2}%2C%22id%22%3A%22{1}%22%7D%2C%22quality%22%3" +
            "A%5B%22{2}%22%5D%7D";

        public StreamReader Download(CookieContainer cookies, int defindex, string id, int quality)
        {
            //return Download(GenerateRequest2(TF2_MART_POST_PARAMS3));

            var req = GenerateRequest(cookies, string.Format(TF2_MART_POST_PARAMS, defindex, id, quality));

            try
            {
                return new StreamReader((req.GetResponse() as HttpWebResponse).GetResponseStream());
            }
            catch (Exception exception)
            {
                // Warning not executed exception
            }
            return null;
        }

        private HttpWebRequest GenerateRequest(CookieContainer cookies, string post)
        {
            var req = (HttpWebRequest) WebRequest.Create("http://tf2mart.net/data/stock/440/page");

            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.Referer = "http://tf2mart.net/order";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) " +
                            "Chrome/53.0.2785.116 YaBrowser/16.10.0.2564 Yowser/2.5 Safari/537.36";

            req.CookieContainer = cookies;

            req.ContentLength = post.Length;
            using (var writer = new StreamWriter(req.GetRequestStream()))
            {
                writer.Write(post);
            }

            return req;
        }
    }
}