using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Steam_monitor.TF2Mart
{
    public class Tf2MartDownload
    {
        public const string TF2_MART_COOKIE = "tf2Mart.dat";

        private readonly List<Cookie> _cookies;

         public Tf2MartDownload()
         {
             _cookies = CookieWorker.LoadFile(TF2_MART_COOKIE);
         }

        public const string TF2_MART_POST_PARAMS1 =
            "filters=%7B%22currency%22%3A%22credits%22%2C%22page%22%3A%7B%22sort%22%3A%7B%22type%22%3A%22type%22%2C%22dir%22%3A%22asc%22%7D%2C%22direction%22%3A1%2C%22size%22%3A22%2C%22defindex%22%3A910%2C%22quality%22%3A{0}%7D%2C%22quality%22%3A%5B%22{0}%22%5D%7D";
            //"qty=50&page=0&filters=%7B%22variations%22%3Afalse%2C%22sort%22%3A%22type%22%2C%22quality%22%3A%5B%22{0}%22%5D%7D";

        public const string TF2_MART_POST_PARAMS2 =
            "filters=%7B%22currency%22%3A%22credits%22%2C%22page%22%3A%7B%22sort%22%3A%7B%22type%22%3A%22type%22%2C%22dir%22%3A%22asc%22%7D%2C%22direction%22%3A1%2C%22size%22%3A50%2C%22defindex%22%3A{0}%2C%22quality%22%3A{2}%2C%22id%22%3A%22{1}%22%7D%2C%22quality%22%3A%5B%22{2}%22%5D%7D";

        public StreamReader Download(int quality)
        {
            return Download(GenerateRequest(string.Format(TF2_MART_POST_PARAMS1, quality)));
        }

        public StreamReader Download(string quality)
        {
            return Download(GenerateRequest(string.Format(TF2_MART_POST_PARAMS1, QualityWorker.GetStringDictionary()[quality])));
        }

        public StreamReader Download(int defindex, string id, int quality)
        {
            //return Download(GenerateRequest2(TF2_MART_POST_PARAMS3));

            return Download(GenerateRequest2(string.Format(TF2_MART_POST_PARAMS2, defindex, id, quality)));
        }

        public StreamReader Download(int defindex, string id, string quality)
        {
            return
                Download(GenerateRequest2(
                    string.Format(TF2_MART_POST_PARAMS2, defindex, id, QualityWorker.GetStringDictionary()[quality])));
        }

        private HttpWebRequest GenerateRequest2(string post)
        {
            var req = (HttpWebRequest)WebRequest.Create("http://tf2mart.net/data/stock/440/page");

            req.Method = "POST";
            req.KeepAlive = true;
            req.Timeout = 10000;
            req.ReadWriteTimeout = 10000;
            req.ContentType = "application/x-www-form-urlencoded";
            req.Referer = "http://tf2mart.net/order";
            req.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.116 YaBrowser/16.10.0.2564 Yowser/2.5 Safari/537.36";

            req.CookieContainer = new CookieContainer();
            foreach (var i in _cookies)
                req.CookieContainer.Add(i);

            req.ContentLength = post.Length;
            using (var writer = new StreamWriter(req.GetRequestStream()))
            {
                writer.Write(post);
            }

            return req;
        }

        private HttpWebRequest GenerateRequest(string post)
        {
            var req = (HttpWebRequest) WebRequest.Create("http://tf2mart.net/data/stock/440/page");

            req.Method = "POST";
            req.KeepAlive = true;
            req.Timeout = 10000;
            req.ReadWriteTimeout = 10000;
            req.ContentType = "application/x-www-form-urlencoded";
            req.Referer = "http://tf2mart.net/order";
            req.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.111 YaBrowser/16.2.0.3539 Safari/537.36";

            req.CookieContainer = new CookieContainer();
            foreach (var i in _cookies)
                req.CookieContainer.Add(i);

            req.ContentLength = post.Length;
            using (var writer = new StreamWriter(req.GetRequestStream()))
            {
                writer.Write(post);
            }

            return req;
        }

        private StreamReader Download(HttpWebRequest req)
        {
            try
            {
                var resp = (HttpWebResponse) req.GetResponse();
                return new StreamReader(resp.GetResponseStream());
            }
            catch (Exception exception)
            {
                Console.WriteLine("Ошибка при загрузке информации с Tf2Mart\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0, 30}", exception.Message + "\n");
                Console.ReadLine();
                Environment.Exit(0);
            }
            return null;
        }
    }
}