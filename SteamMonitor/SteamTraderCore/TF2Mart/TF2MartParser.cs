using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using SteamMonitor.SteamTraderCore.TF2Mart.Json;
using Steam_monitor;

namespace SteamMonitor.SteamTraderCore.TF2Mart
{
    public class Tf2MartParser
    {
        public bool NextFlag { get; set; }

        public List<Item> GetItems(StreamReader response)
        {
            var items = new List<Item>();

            string s = response.ReadToEnd();

            var download = new Tf2MartResponse();
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(s)))
            {
                var ser = new DataContractJsonSerializer(download.GetType(),
                    new DataContractJsonSerializerSettings
                    {
                        UseSimpleDictionaryFormat = true
                    });
                download = ser.ReadObject(ms) as Tf2MartResponse;

                items.AddRange(download.Positions.Select(t => new Item
                {
                    buyPrice = t.Price.Sell,
                    sellPrice = t.Price.Buy,
                    fullName = "",
                    quality = t.Quality,
                    defindex = t.Defindex,
                    id = t.Id
                }));

                NextFlag = download.Next;
            }

            return items;
        }
    }
}