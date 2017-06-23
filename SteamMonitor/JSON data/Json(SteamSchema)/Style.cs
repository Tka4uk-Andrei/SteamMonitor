using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class Style
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "additional_hidden_bodygroups")]
        public AdditionalHiddenBodygroups AdditionalHiddenBodygroups { get; set; }
    }
}