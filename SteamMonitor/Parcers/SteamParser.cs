using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using SteamMonitor.SteamTraderCore.Steam.Json;

namespace SteamMonitor.SteamTraderCore.Steam
{
    public class SteamParser
    {
        public SteamParser()
        {
            MaxPage = 0;
        }

        public int MaxPage { get; set; }

        public List<Item> GetItems(StreamReader response)
        {
            var doc = new HtmlDocument();

            var steamResponse = Serilization(response);

            MaxPage = steamResponse.TotalCount;

            doc.LoadHtml(steamResponse.ResultsHtml);

            var priceCollection = doc.DocumentNode.SelectNodes("//*[@id]/div[1]/div[2]/span[1]/span[1]");
            var nameCollection = doc.DocumentNode.SelectNodes("/a/div[1]/div[2]/span[1]");

            var items = new List<Item>();

            Item item;
            var reg = new Regex(@"[^ pуб.]");
            for (var i = 0; i < priceCollection.Count; ++i)
            {
                var p = reg.Matches(priceCollection[i].InnerText)
                    .Cast<object>()
                    .Aggregate("", (current, j) => current + j);

                item = new Item
                {
                    Quality = -1,
                    BuyPrice = double.Parse(p),
                    FullName = nameCollection[i].InnerText,
                    Defindex = -1,
                    SellPrice = double.Parse(p)*0.87
                };

                items.Add(item);
            }

            return items;
        }

        private SteamItemsJsonResponse Serilization(StreamReader response)
        {
            var download = new SteamItemsJsonResponse();
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(response.ReadToEnd())))
            {
                var ser = new DataContractJsonSerializer(download.GetType(),
                    new DataContractJsonSerializerSettings
                    {
                        UseSimpleDictionaryFormat = true
                    });

                download = ser.ReadObject(ms) as SteamItemsJsonResponse;
            }

            return download;
        }
    }
}