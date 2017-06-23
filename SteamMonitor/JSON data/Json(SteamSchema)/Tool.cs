using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class Tool
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "usage_capabilities")]
        public UsageCapabilities UsageCapabilities { get; set; }

        [DataMember(Name = "use_string")]
        public string UseString { get; set; }

        [DataMember(Name = "restriction")]
        public string Restriction { get; set; }
    }
}