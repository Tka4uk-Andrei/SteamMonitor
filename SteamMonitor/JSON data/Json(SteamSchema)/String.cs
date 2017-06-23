using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class String
    {
        [DataMember(Name = "index")]
        public int Index { get; set; }

        [DataMember(Name = "string")]
        public string ItemString { get; set; }
    }
}