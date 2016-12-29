using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HtmlAgilityPack;
using Steam_monitor.Steam.Json;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Steam_monitor
{
    public class SteamParser
    {
        public int maxPage { get; set; } = 0;

        public List<Item> getItems(StreamReader response)
        {
            var doc = new HtmlDocument();

            var steamResponse = Serilization(response);

            maxPage = steamResponse.TotalCount;

            doc.LoadHtml(steamResponse.ResultsHtml);

            var priceCollection = doc.DocumentNode.SelectNodes("//*[@id]/div[1]/div[2]/span[1]/span[1]");
            var nameCollection = doc.DocumentNode.SelectNodes("/a/div[1]/div[2]/span[1]");

            List<Item> items = new List<Item>();

            Item item;
            var reg = new Regex(@"[^ pуб.]");
            for (int i = 0; i < priceCollection.Count; ++i)
            {
                var p = reg.Matches(priceCollection[i].InnerText).Cast<object>().Aggregate("", (current, j) => current + j);

                item = new Item()
                {
                    quality = -1,
                    buyPrice = double.Parse(p),
                    fullName = nameCollection[i].InnerText,
                    defindex = -1,
                    sellPrice = double.Parse(p) * 0.87
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