using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class ItemSets
    {
        [DataMember(Name = "item_set")]
        public string ItemSet { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "items")]
        public string[] Items { get; set; }

        [DataMember(Name = "attributes")]
        public Attribute[] Attributes { get; set; }

        [DataMember(Name = "store_bundle")]
        public string StoreBundle { get; set; }
    }
}