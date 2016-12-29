using System.Runtime.Serialization;

namespace Steam_monitor.Steam.Json
{
    [DataContract]
    public class Assets
    {
        [DataMember(Name = "currency")]
        public int Currency { get; set; }

        [DataMember(Name = "appid")]
        public int Appid { get; set; }

        [DataMember(Name = "contextid")]
        public string ContextId { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "classid")]
        public string ClassId { get; set; }

        [DataMember(Name = "instanceid")]
        public string InstanceId { get; set; }

        [DataMember(Name = "amount")]
        public string Amount { get; set; }

        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "original_amount")]
        public string OriginalAmount { get; set; }

        [DataMember(Name = "background_color")]
        public string BackgroundColor { get; set; }

        [DataMember(Name = "icon_url")]
        public string IconUrl { get; set; }

        [DataMember(Name = "icon_url_large")]
        public string IconUrlLarge { get; set; }

        [DataMember(Name = "descriptions")]
        public Description[] Descriptions { get; set; }

        [DataMember(Name = "tradable")]
        public int Tradable { get; set; }

        [DataMember(Name = "actions")]
        public Action[] Actions { get; set; }

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

        [DataMember(Name = "commodity")]
        public int Commodity { get; set; }

        [DataMember(Name = "market_tradable_restriction")]
        public int MarketTradableRestriction { get; set; }

        [DataMember(Name = "market_marketable_restriction")]
        public int MarketMarketableRestriction { get; set; }

        [DataMember(Name = "app_icon")]
        public string AppIcon { get; set; }

        [DataMember(Name = "owner")]
        public int Owner { get; set; }
    }
}