using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using SteamMonitor.SteamMarketItems.inventoryJson;

namespace SteamMonitor.SteamMarketItems
{
    internal class RequestParcer
    {
        public static List<ItemInfo> GetItemInfos(StreamReader input)
        {
            var doc = new HtmlDocument();

            doc.LoadHtml(input.ReadToEnd());

            var names =
                doc.DocumentNode.SelectNodes("//div[@id=\"tabContentsMyActiveMarketListingsRows\"]/div/div[4]/span/a");
            var listingIds =
                doc.DocumentNode.SelectNodes("//div[@id=\"tabContentsMyActiveMarketListingsRows\"]/div/div[5]/div/a");
            var prices =
                doc.DocumentNode.SelectNodes(
                    "//div[@id=\"tabContentsMyActiveMarketListingsRows\"]/div/div[2]/span/span/span/span[1]");

            var items = new List<ItemInfo>();

            var reg = new Regex(@"[^ pуб.]");
            if (listingIds != null)
            {
                for (var i = 0; i < listingIds.Count; ++i)
                {
                    var s =
                        listingIds[i].Attributes[0].Value.Substring(
                            "javascript: RemoveMarketListing(\'mylisting\', \'".Length - 1);
                    s = s.Substring(0, s.IndexOf('\''));

                    var p = reg.Matches(prices[i].InnerText)
                        .Cast<object>()
                        .Aggregate("", (current, j) => current + j);

                    items.Add(new ItemInfo
                    {
                        Name = names[i].InnerText,
                        ListingId = s,
                        Price = (int) (double.Parse(p)*100)
                    });
                }
            }
            return items;
        }

        public static List<ItemInfo> ParceInventory(StreamReader input)
        {
            var items = new List<ItemInfo>();

            var response = new Rootobject();
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(input.ReadToEnd())))
            {
                var ser = new DataContractJsonSerializer(response.GetType(),
                    new DataContractJsonSerializerSettings {UseSimpleDictionaryFormat = true});

                response = ser.ReadObject(ms) as Rootobject;
            }

            for (var i = 0; i < response.Assets.Length; ++i)
            {
                for (var j = 0; j < response.Descriptions.Length; ++j)
                {
                    if (response.Assets[i].ClassId == response.Descriptions[j].ClassId &&
                        response.Descriptions[j].Marketable == 1 &&
                        response.Descriptions[j].MarketName != "Mann Co. Supply Crate Key")
                    {
                        items.Add(new ItemInfo
                        {
                            Name = response.Descriptions[j].MarketName,
                            AssetId = response.Assets[i].AssetId,
                            Price = int.MaxValue
                        });

                        break;
                    }
                }
            }

            return items;
        }
    }
}