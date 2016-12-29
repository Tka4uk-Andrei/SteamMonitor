using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class Qualities
    {
        [DataMember(Name = "Normal")]
        public int Normal { get; set; }

        [DataMember(Name = "rarity1")]
        public int Rarity1 { get; set; }

        [DataMember(Name = "rarity2")]
        public int Rarity2 { get; set; }

        [DataMember(Name = "vintage")]
        public int Vintage { get; set; }

        [DataMember(Name = "rarity3")]
        public int Rarity3 { get; set; }

        [DataMember(Name = "rarity4")]
        public int Rarity4 { get; set; }

        [DataMember(Name = "Unique")]
        public int Unique { get; set; }

        [DataMember(Name = "community")]
        public int Community { get; set; }

        [DataMember(Name = "developer")]
        public int Developer { get; set; }

        [DataMember(Name = "selfmade")]
        public int Selfmade { get; set; }

        [DataMember(Name = "customized")]
        public int Customized { get; set; }

        [DataMember(Name = "strange")]
        public int Strange { get; set; }

        [DataMember(Name = "completed")]
        public int Completed { get; set; }

        [DataMember(Name = "haunted")]
        public int Haunted { get; set; }

        [DataMember(Name = "collectors")]
        public int Collectors { get; set; }

        [DataMember(Name = "paintkitweapon")]
        public int Paintkitweapon { get; set; }
    }
}