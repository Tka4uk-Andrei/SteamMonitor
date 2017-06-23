using System.Collections.Generic;
using System.IO;
using System.Net;

namespace SteamMonitor.StaticData.Cookies
{
    internal class SteamCookies
    {
        private static readonly string FileName = "steam.dat";

        private static SteamCookies _cookies;
        private readonly CookieContainer _cookieContainer;

        private SteamCookies()
        {
            var cookieReader = new StreamReader(FileName);

            var cookies = new List<Cookie>();
            while (!cookieReader.EndOfStream)
            {
                cookies.Add(new Cookie(
                    cookieReader.ReadLine(),
                    cookieReader.ReadLine(),
                    "/",
                    ".steamcommunity.com")
                    );
            }
            cookieReader.Close();

            _cookieContainer = new CookieContainer();
            for (var i = 0; i < cookies.Count; ++i)
                _cookieContainer.Add(cookies[i]);
        }

        public static SteamCookies GetStatus()
        {
            return _cookies ?? (_cookies = new SteamCookies());
        }

        public CookieContainer GetCookieContainer()
        {
            return _cookieContainer;
        }
    }
}