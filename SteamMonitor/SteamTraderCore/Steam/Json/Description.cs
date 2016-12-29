using System.Runtime.Serialization;

namespace Steam_monitor.Steam.Json
{
    [DataContract]
    public class Description
    {
        [DataMember(Name = "value")]
        public string Value { get; set; }

        [DataMember(Name = "color")]
        public string Color { get; set; }
    }
}