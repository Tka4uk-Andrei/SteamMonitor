using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class Qualitynames
    {
        [DataMember(Name = "Normal")]
        public string Normal { get; set; }

        [DataMember(Name = "rarity1")]
        public string Rarity1 { get; set; }

        [DataMember(Name = "rarity2")]
        public string Rarity2 { get; set; }

        [DataMember(Name = "vintage")]
        public string Vintage { get; set; }

        [DataMember(Name = "rarity3")]
        public string Rarity3 { get; set; }

        [DataMember(Name = "rarity4")]
        public string Rarity4 { get; set; }

        [DataMember(Name = "Unique")]
        public string Unique { get; set; }

        [DataMember(Name = "community")]
        public string Community { get; set; }

        [DataMember(Name = "developer")]
        public string Developer { get; set; }

        [DataMember(Name = "selfmade")]
        public string Selfmade { get; set; }

        [DataMember(Name = "customized")]
        public string Customized { get; set; }

        [DataMember(Name = "strange")]
        public string Strange { get; set; }

        [DataMember(Name = "completed")]
        public string Completed { get; set; }

        [DataMember(Name = "haunted")]
        public string Haunted { get; set; }

        [DataMember(Name = "collectors")]
        public string Collectors { get; set; }

        [DataMember(Name = "paintkitweapon")]
        public string Paintkitweapon { get; set; }
    }
}