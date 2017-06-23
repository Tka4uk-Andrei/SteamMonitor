using System.IO;
using System.Net;
using SteamMonitor.StaticData.Cookies;

namespace SteamMonitor.Requests.Steam
{
    internal static class GetSteamMarketListings
    {
        public static StreamReader GetMarketSellList()
        {
            var req = (HttpWebRequest)WebRequest.Create("http://steamcommunity.com/market/");

            req.Method = "GET";
            req.CookieContainer = SteamCookies.GetStatus().GetCookieContainer();
            req.ContentType = "application/x-www-form-urlencoded";
            req.Referer = "http://steamcommunity.com/profiles/76561198073577944/inventory?modal=1&market=1";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) " +
                            "Chrome/53.0.2785.116 YaBrowser/16.10.0.2564 Yowser/2.5 Safari/537.36";

            return new StreamReader((req.GetResponse() as HttpWebResponse).GetResponseStream());
        }
    }
}