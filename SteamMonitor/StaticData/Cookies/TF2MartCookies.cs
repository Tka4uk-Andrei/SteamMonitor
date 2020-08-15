using SteamMonitor.JSON_data.Json_cookies_;
using System.Runtime.Serialization.Json;
using System;
using System.Text;
using System.IO;
using System.Net;

namespace SteamMonitor.StaticData.Cookies
{
    // ReSharper disable once InconsistentNaming
    public class TF2MartCookies
    {
        private static readonly string FileName = "cookies.json";

        private static TF2MartCookies _cookies;
        private readonly CookieContainer _cookieContainer;

        // todo unification with SteamCookies
        private TF2MartCookies()
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

            for (var i = 0; i < cookieDataContainer.Tf2MartCookieDatas.Length; ++i)
            {
                var c = cookieDataContainer.Tf2MartCookieDatas[i];
                _cookieContainer.Add(new Cookie(c.Name, c.Value, c.Path, c.Domain));
            }

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