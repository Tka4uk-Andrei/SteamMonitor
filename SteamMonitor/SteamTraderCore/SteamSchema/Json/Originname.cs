using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class Originname
    {
        [DataMember(Name = "origin")]
        public int Origin { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}