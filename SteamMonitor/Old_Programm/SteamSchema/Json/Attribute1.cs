using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class Attribute1
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "defindex")]
        public int Defindex { get; set; }

        [DataMember(Name = "attribute_class")]
        public string AttributeClass { get; set; }

        [DataMember(Name = "description_string")]
        public string DescriptionString { get; set; }

        [DataMember(Name = "description_format")]
        public string DescriptionFormat { get; set; }

        [DataMember(Name = "effect_type")]
        public string EffectType { get; set; }

        [DataMember(Name = "hidden")]
        public bool Hidden { get; set; }

        [DataMember(Name = "stored_as_integer")]
        public bool StoredAsInteger { get; set; }
    }
}