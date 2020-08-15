using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class Result
    {
        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "items_game_url")]
        public string ItemsGameUrl { get; set; }

        [DataMember(Name = "qualities")]
        public Dictionary<string, int> Qualities { get; set; }

        [DataMember(Name = "qualityNames")]
        public Dictionary<string, string> QualityNames { get; set; }
         
        [DataMember(Name = "originNames")]
        public Originname[] OriginNames { get; set; }

        [DataMember(Name = "items")]
        public Item[] Items { get; set; }

        [DataMember(Name = "attributes")]
        public Attribute1[] Attributes { get; set; }

        [DataMember(Name = "item_sets")]
        public ItemSets[] ItemSets { get; set; }

        [DataMember(Name = "attribute_controlled_attached_particles")]
        public AttributeControlledAttachedParticles[] AttributeControlledAttachedParticles { get; set; }

        [DataMember(Name = "item_levels")]
        public ItemLevels[] ItemLevels { get; set; }

        [DataMember(Name = "kill_eater_score_types")]
        public KillEaterScoreTypes[] KillEaterScoreTypes { get; set; }

        [DataMember(Name = "string_lookups")]
        public StringLookups[] StringLookups { get; set; }

        [DataMember(Name = "next")]
        public int Next { get; set; }
    }
}