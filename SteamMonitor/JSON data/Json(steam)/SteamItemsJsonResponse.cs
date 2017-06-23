using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SteamMonitor.SteamTraderCore.Steam.Json
{
    [DataContract]
    internal class SteamItemsJsonResponse
    {
        [DataMember(Name = "success")]
        public bool Success { get; set; }

        [DataMember(Name = "start")]
        public int Start { get; set; }

        [DataMember(Name = "pagesize")]
        public string Pagesize { get; set; }

        [DataMember(Name = "total_count")]
        public int TotalCount { get; set; }

        [DataMember(Name = "results_html")]
        public string ResultsHtml { get; set; }

        [DataMember(Name = "listinginfo")]
        public Dictionary<string, Listinginfo> Listinginfo { get; set; }

        [DataMember(Name = "assets")]
        public Dictionary<string, Dictionary<string, Dictionary<string, Assets>>> Assets { get; set; }

        [DataMember(Name = "currency")]
        public object[] Currency { get; set; }

        [DataMember(Name = "hovers")]
        public string Hovers { get; set; }

        [DataMember(Name = "app_data")]
        public Dictionary<string, AppData> AppData { get; set; }
    }
}