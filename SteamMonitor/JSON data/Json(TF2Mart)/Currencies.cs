using System.Runtime.Serialization;

namespace SteamMonitor.SteamTraderCore.TF2Mart.Json
{
    [DataContract]
    public class Currencies
    {
        [DataMember(Name = "ref")]
        public Ref Ref { get; set; }

        [DataMember(Name = "key")]
        public Key Key { get; set; }
    }
}
