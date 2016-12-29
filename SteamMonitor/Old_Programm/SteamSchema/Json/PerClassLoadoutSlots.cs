using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class PerClassLoadoutSlots
    {
        [DataMember(Name = "Soldier")]
        public string Soldier { get; set; }

        [DataMember(Name = "Heavy")]
        public string Heavy { get; set; }

        [DataMember(Name = "Pyro")]
        public string Pyro { get; set; }

        [DataMember(Name = "Engineer")]
        public string Engineer { get; set; }

        [DataMember(Name = "Demoman")]
        public string Demoman { get; set; }
    }
}