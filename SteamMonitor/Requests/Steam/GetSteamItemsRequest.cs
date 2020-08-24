using System;
using System.IO;
using System.Net;

namespace SteamMonitor.SteamTraderCore.Steam
{
    public class GetSteamItemsRequest
    {
        private const string STEAM_MARKET_ITEM =
            "http://steamcommunity.com/market/search/render/?query={0}&start={1}&count=100&curency=5&appid=440&sort_column=name&sort_dir=asc";

        public int StartCount { get; set; } = 0;

        public StreamReader Download(CookieContainer cookies, int quality)
        {
            var req = GenerateRequest(cookies, quality);

            try
            {
                return new StreamReader((req.GetResponse() as HttpWebResponse).GetResponseStream());
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private HttpWebRequest GenerateRequest(CookieContainer cookies, int quality)
        {
            var req =
                (HttpWebRequest)
                    WebRequest.Create(string.Format(STEAM_MARKET_ITEM, QualityWorker.IdDictionary[quality],
                        StartCount));

            req.Method = "GET";
            req.KeepAlive = true;

            req.CookieContainer = cookies;

            return req;
        }
    }
}