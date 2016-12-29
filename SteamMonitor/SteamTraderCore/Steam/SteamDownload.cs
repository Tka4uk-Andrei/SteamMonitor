using System;
using System.IO;
using System.Net;
using Steam_monitor;

namespace SteamMonitor.SteamTraderCore.Steam
{
    public class SteamDownload
    {
        private const string STEAM_MARKET_ITEM =
            "http://steamcommunity.com/market/search/render/?query={0}&start={1}&count=100&curency=5&appid=440&sort_column=name&sort_dir=asc";

        // TODO constructor with Cookie load
        // TODO set quality

        public int StartCount { get; set; } = 0;

        public StreamReader Download(string cookiePath, int quality)
        {
            return download(GenerateRequest(cookiePath, quality));
        }

        public StreamReader Download(string cookiePath, string quality)
        {
            return download(GenerateRequest(cookiePath, quality));
        }

        private HttpWebRequest GenerateRequest(string cookiePath, string quality)
        {
            var req = (HttpWebRequest) WebRequest.Create(string.Format(STEAM_MARKET_ITEM, quality, StartCount));
            return SetSettingsToRequest(req, cookiePath);
        }

        private HttpWebRequest GenerateRequest(string cookiePath, int quality)
        {
            var req =
                (HttpWebRequest)
                    WebRequest.Create(string.Format(STEAM_MARKET_ITEM, QualityWorker.GetIdDictionary()[quality],
                        StartCount));
            return SetSettingsToRequest(req, cookiePath);
        }

        private HttpWebRequest SetSettingsToRequest(HttpWebRequest req, string cookiePath)
        {
            req.Method = "GET";
            req.KeepAlive = true;

            req.CookieContainer = new CookieContainer();
            foreach (var i in CookieWorker.LoadFile(cookiePath))
                req.CookieContainer.Add(i);

            return req;
        }

        private StreamReader download(HttpWebRequest req)
        {
            try
            {
                var resp = (HttpWebResponse) req.GetResponse();
                return new StreamReader(resp.GetResponseStream());
            }
            catch (Exception exception)
            {
                //Console.WriteLine("Ошибка при загрузке информации со Steam");
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("{0, 30}", exception.Message + "\n");
                //Console.ReadLine();
                //Environment.Exit(0);
            }
            return null;
        }
    }
}