using System.Runtime.Serialization;

namespace SteamMonitor.SteamAdditionalInfo.Json
{
    [DataContract]
    public class SteamResponse
    {
        [DataMember(Name = "lowest_price")]
        public string LowestPrice { get; set; }

        [DataMember(Name = "median_price")]
        public string MedianPrice { get; set; }

        [DataMember(Name = "success")]
        public bool Success { get; set; }

        [DataMember(Name = "volume")]
        public string Volume { get; set; }
    }
}