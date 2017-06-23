using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class KillEaterScoreTypes
    {
        [DataMember(Name = "type")]
        public int Type { get; set; }

        [DataMember(Name = "type_name")]
        public string TypeName { get; set; }

        [DataMember(Name = "level_data")]
        public string LevelData { get; set; }
    }
}