using System.Collections.Generic;
using System.IO;
using System.Net;

namespace SteamMonitor.StaticData.Cookies
{
    // ReSharper disable once InconsistentNaming
    public class TF2MartCookies
    {
        private static readonly string FileName = "tf2Mart.dat";

        private static TF2MartCookies _cookies;
        private readonly CookieContainer _cookieContainer;

        private TF2MartCookies()
        {
            _cookieContainer = new CookieContainer();

            foreach (Cookie cookie in LoadCookiesFromFile())
                _cookieContainer.Add(cookie);
        }

        private static List<Cookie> LoadCookiesFromFile()
        {
            var cookieReader = new StreamReader(FileName);

            var cookies = new List<Cookie>();
            while (!cookieReader.EndOfStream)
            {
                cookies.Add(new Cookie(
                    cookieReader.ReadLine(),
                    cookieReader.ReadLine(),
                    cookieReader.ReadLine(),
                    cookieReader.ReadLine())
                    );
            }
            cookieReader.Close();

            return cookies;
        }

        public static TF2MartCookies GetStatus()
        {
            return _cookies ?? (_cookies = new TF2MartCookies());
        }

        public CookieContainer GetCookieContainer()
        {
            return _cookieContainer;
        }
    }
}