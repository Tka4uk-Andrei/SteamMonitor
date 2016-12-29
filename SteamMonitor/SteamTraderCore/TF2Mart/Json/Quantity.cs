using System.Runtime.Serialization;

namespace SteamMonitor.SteamTraderCore.TF2Mart.Json
{
    [DataContract]
    public class Quantity
    {
        [DataMember(Name = "buy")]
        public int Buy { get; set; }

        [DataMember(Name = "sell")]
        public int Sell { get; set; }

        [DataMember(Name = "limit")]
        public int Limit { get; set; }
    }
}
