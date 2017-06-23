using System.Runtime.Serialization;

namespace SteamMonitor.SteamTraderCore.Steam.Json
{
    [DataContract]
    public class Asset
    {
        [DataMember(Name = "currency")]
        public int Currency { get; set; }

        [DataMember(Name = "appid")]
        public int Appid { get; set; }

        [DataMember(Name = "contextid")]
        public string ContextId { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "amount")]
        public string Amount { get; set; }
    }
}