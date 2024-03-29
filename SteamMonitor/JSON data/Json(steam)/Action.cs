using System.Runtime.Serialization;

namespace SteamMonitor.SteamTraderCore.Steam.Json
{
    [DataContract]
    public class Action
    {
        [DataMember(Name = "link")]
        public string Link { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}