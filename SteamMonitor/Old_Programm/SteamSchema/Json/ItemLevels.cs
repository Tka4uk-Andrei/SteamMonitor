using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class ItemLevels
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "levels")]
        public Level[] Levels { get; set; }
    }
}