using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class AdditionalHiddenBodygroups
    {
        [DataMember(Name = "hat")]
        public int Hat { get; set; }

        [DataMember(Name = "headphones")]
        public int Headphones { get; set; }

        [DataMember(Name = "head")]
        public int Head { get; set; }
    }
}