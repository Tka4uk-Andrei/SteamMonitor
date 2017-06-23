using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class Item
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "defindex")]
        public int Defindex { get; set; }

        [DataMember(Name = "item_class")]
        public string ItemClass { get; set; }

        [DataMember(Name = "item_type_name")]
        public string ItemTypeName { get; set; }

        [DataMember(Name = "item_name")]
        public string ItemName { get; set; }

        [DataMember(Name = "proper_name")]
        public bool ProperName { get; set; }

        [DataMember(Name = "item_slot")]
        public string ItemSlot { get; set; }

        [DataMember(Name = "model_player")]
        public string ModelPlayer { get; set; }

        [DataMember(Name = "item_quality")]
        public int ItemQuality { get; set; }

        [DataMember(Name = "image_inventory")]
        public string ImageInventory { get; set; }

        [DataMember(Name = "min_ilevel")]
        public int MinIlevel { get; set; }

        [DataMember(Name = "max_ilevel")]
        public int MaxIlevel { get; set; }

        [DataMember(Name = "image_url")]
        public string ImageUrl { get; set; }

        [DataMember(Name = "image_url_large")]
        public string ImageUrlLarge { get; set; }

        [DataMember(Name = "craft_class")]
        public string CraftClass { get; set; }

        [DataMember(Name = "craft_material_type")]
        public string CraftMaterialType { get; set; }

        [DataMember(Name = "capabilities")]
        public Capabilities Capabilities { get; set; }

        [DataMember(Name = "used_by_classes")]
        public string[] UsedByClasses { get; set; }

        [DataMember(Name = "item_description")]
        public string ItemDescription { get; set; }

        [DataMember(Name = "styles")]
        public Style[] Styles { get; set; }

        [DataMember(Name = "attributes")]
        public Attribute[] Attributes { get; set; }

        [DataMember(Name = "drop_type")]
        public string DropType { get; set; }

        [DataMember(Name = "item_set")]
        public string ItemSet { get; set; }

        [DataMember(Name = "holiday_restriction")]
        public string HolidayRestriction { get; set; }

        [DataMember(Name = "per_class_loadout_slots")]
        public PerClassLoadoutSlots PerClassLoadoutSlots { get; set; }

        [DataMember(Name = "tool")]
        public Tool Tool { get; set; }
    }
}
