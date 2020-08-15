using SteamMonitor.JSON_data.Json_cookies_;
using System.Runtime.Serialization.Json;
using System;
using System.Text;
using System.IO;
using System.Net;

namespace SteamMonitor.StaticData.Cookies
{
    internal class SteamCookies
    {
        private static readonly string FileName = "cookies.json";

        private static SteamCookies _cookies;
        private readonly CookieContainer _cookieContainer;

        // todo unification with TF2MartCookies
        private SteamCookies()
        {
            var cookieReader = new StreamReader(FileName);

            var cookieDataContainer = new CookiesDataContainer();
            _cookieContainer = new CookieContainer();

            try
            {
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(cookieReader.ReadToEnd())))
                {
                    var ser = new DataContractJsonSerializer(cookieDataContainer.GetType(),
                        new DataContractJsonSerializerSettings
                        {
                            UseSimpleDictionaryFormat = true
                        });
                    cookieDataContainer = ser.ReadObject(ms) as CookiesDataContainer;
                }
            }
            catch (Exception)
            {
                return;
            }

            for (var i = 0; i < cookieDataContainer.SteamCookieDatas.Length; ++i)
            {
                var c = cookieDataContainer.SteamCookieDatas[i];
                _cookieContainer.Add(new Cookie(c.Name, c.Value, c.Path, c.Domain));
            }
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