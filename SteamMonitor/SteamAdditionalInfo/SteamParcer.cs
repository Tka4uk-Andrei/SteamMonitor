﻿using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using SteamMonitor.SteamAdditionalInfo.Json;

namespace SteamMonitor.SteamAdditionalInfo
{
    internal static class SteamParcer
    {
        public static Additionalnfo Parce(StreamReader response, string itemName)
        {
            var item = new Additionalnfo();

            var resp = new SteamResponse();
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(response.ReadToEnd())))
            {
                var ser = new DataContractJsonSerializer(resp.GetType(),
                    new DataContractJsonSerializerSettings
                    {
                        UseSimpleDictionaryFormat = true
                    });
                resp = ser.ReadObject(ms) as SteamResponse;

                item.Name = itemName;
                item.SoldCountPerDay = int.Parse(resp.Volume);
            }

            return item;
        }
    }
}