using System.Runtime.Serialization;

namespace SteamMonitor.SteamMarketItems.inventoryJson
{
    [DataContract]
    public class Rootobject
    {
        [DataMember(Name = "assets")]
        public Asset[] Assets { get; set; }

        [DataMember(Name = "descriptions")]
        public Description[] Descriptions { get; set; }

        [DataMember(Name = "rwgrsn")]
        public int Rwgrsn { get; set; }

        [DataMember(Name = "success")]
        public int Success { get; set; }

        [DataMember(Name = "total_inventory_count")]
        public int TotalInventoryCount { get; set; }
    }

    [DataContract]
    public class Asset
    {
        [DataMember(Name = "appid")]
        public string AppId { get; set; }

        [DataMember(Name = "contextid")]
        public string ContextId { get; set; }

        [DataMember(Name = "assetid")]
        public string AssetId { get; set; }

        [DataMember(Name = "classid")]
        public string ClassId { get; set; }

        [DataMember(Name = "instanceid")]
        public string InstanceId { get; set; }

        [DataMember(Name = "amount")]
        public string Amount { get; set; }
    }

    [DataContract]
    public class Description
    {
        [DataMember(Name = "appid")]
        public int Appid { get; set; }

        [DataMember(Name = "classid")]
        public string ClassId { get; set; }

        [DataMember(Name = "instanceid")]
        public string InstanceId { get; set; }

        [DataMember(Name = "currency")]
        public int Currency { get; set; }

        [DataMember(Name = "background_color")]
        public string BackgroundColor { get; set; }

        [DataMember(Name = "icon_url")]
        public string IconUrl { get; set; }

        [DataMember(Name = "icon_url_large")]
        public string IconUrlLarge { get; set; }

        [DataMember(Name = "descriptions")]
        public object[] Descriptions { get; set; }

        [DataMember(Name = "tradable")]
        public int Tradable { get; set; }

        [DataMember(Name = "actions")]
        public object[] Actions { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "name_color")]
        public string NameColor { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "market_name")]
        public string MarketName { get; set; }

        [DataMember(Name = "market_hash_name")]
        public string MarketHashName { get; set; }

        [DataMember(Name = "market_actions")]
        public object[] MarketActions { get; set; }

        [DataMember(Name = "commodity")]
        public int Commodity { get; set; }

        [DataMember(Name = "market_tradable_restriction")]
        public int MarketTradableRestriction { get; set; }

        [DataMember(Name = "market_marketable_restriction")]
        public int MarketMarketableRestriction { get; set; }

        [DataMember(Name = "marketable")]
        public int Marketable { get; set; }

        [DataMember(Name = "tags")]
        public object[] Tags { get; set; }
    }
}