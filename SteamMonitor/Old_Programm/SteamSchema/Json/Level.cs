using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class Level
    {
        [DataMember(Name = "level")]
        public int ItemLevel { get; set; }

        [DataMember(Name = "required_score")]
        public int RequiredScore { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}