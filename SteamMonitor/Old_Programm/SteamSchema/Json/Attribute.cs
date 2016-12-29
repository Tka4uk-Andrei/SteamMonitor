using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class Attribute
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "class")]
        public string Class { get; set; }

        [DataMember(Name = "value")]
        public float Value { get; set; }
    }
}