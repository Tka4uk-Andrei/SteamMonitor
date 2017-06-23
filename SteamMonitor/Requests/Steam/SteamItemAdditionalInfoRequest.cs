using System;
using System.IO;
using System.Net;
using SteamMonitor.StaticData.Cookies;

namespace SteamMonitor.SteamAdditionalInfo
{
    internal class SteamItemAdditionalInfoRequest
    {
        private const string REQUEST_URI =
            "http://steamcommunity.com/market/priceoverview/?country=RU&currency=5&appid=440&market_hash_name={0}";

        public static StreamReader Download(string itemName)
        {
            var req = (HttpWebRequest) WebRequest.Create(string.Format(REQUEST_URI, itemName));

            req.Method = "GET";
            req.KeepAlive = true;
            req.CookieContainer = SteamCookies.GetStatus().GetCookieContainer();

            try
            {
                return new StreamReader((req.GetResponse() as HttpWebResponse).GetResponseStream());
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}