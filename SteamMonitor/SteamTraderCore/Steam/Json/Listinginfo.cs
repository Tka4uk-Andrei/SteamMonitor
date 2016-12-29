using System.Runtime.Serialization;

namespace Steam_monitor.Steam.Json
{
    [DataContract]
    public class Listinginfo
    {
        [DataMember(Name = "listingid")]
        public string Listingid { get; set; }

        [DataMember(Name = "price")]
        public int Price { get; set; }

        [DataMember(Name = "fee")]
        public int Fee { get; set; }

        [DataMember(Name = "publisher_fee_app")]
        public int PublisherFeeApp { get; set; }

        [DataMember(Name = "publisher_fee_percent")]
        public string PublisherFeePercent { get; set; }

        [DataMember(Name = "currencyid")]
        public string Currencyid { get; set; }

        [DataMember(Name = "steam_fee")]
        public int SteamFee { get; set; }

        [DataMember(Name = "publisher_fee")]
        public int PublisherFee { get; set; }

        [DataMember(Name = "converted_price")]
        public int ConvertedPrice { get; set; }

        [DataMember(Name = "converted_fee")]
        public int ConvertedFee { get; set; }

        [DataMember(Name = "converted_currencyid")]
        public string ConvertedCurrencyid { get; set; }

        [DataMember(Name = "converted_steam_fee")]
        public int ConvertedSteamFee { get; set; }

        [DataMember(Name = "converted_publisher_fee")]
        public int ConvertedPublisherFee { get; set; }

        [DataMember(Name = "converted_price_per_unit")]
        public int ConvertedPricePerUnit { get; set; }

        [DataMember(Name = "converted_fee_per_unit")]
        public int ConvertedFeePerUnit { get; set; }

        [DataMember(Name = "converted_steam_fee_per_unit")]
        public int ConvertedSteamFeePerUnit { get; set; }

        [DataMember(Name = "converted_publisher_fee_per_units")]
        public int ConvertedPublisherFeePerUnit { get; set; }

        [DataMember(Name = "asset")]
        public Asset Asset { get; set; }
    }
}