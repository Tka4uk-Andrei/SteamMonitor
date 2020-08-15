using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SteamMonitor.JSON_data.Json_cookies_
{
    [DataContract]
    public class CookiesDataContainer
    {
        [DataMember(Name = "steam_market")]
        public CookieData[] SteamCookieDatas { get; set; }
        [DataMember(Name = "tf2mart")]
        public CookieData[] Tf2MartCookieDatas { get; set; }
    }

    [DataContract]
    public class CookieData
    {
        [DataMember(Name = "domain")]
        public string Domain { get; set; }
        [DataMember(Name = "expirationDate")]
        public float ExpirationDate { get; set; }
        [DataMember(Name = "hostOnly")]
        public bool HostOnly { get; set; }
        [DataMember(Name = "httpOnly")]
        public bool HttpOnly { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "path")]
        public string Path { get; set; }
        [DataMember(Name = "sameSite")]
        public string SameSite { get; set; }
        [DataMember(Name = "secure")]
        public bool Secure { get; set; }
        [DataMember(Name = "session")]
        public bool Session { get; set; }
        [DataMember(Name = "storeId")]
        public string StoreId { get; set; }
        [DataMember(Name = "value")]
        public string Value { get; set; }
        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}
