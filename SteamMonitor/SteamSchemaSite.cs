using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Steam_monitor.SteamSchema;
using Steam_monitor.SteamSchema.Json;

namespace SteamMonitor.SteamTraderCore.SteamSchema
{
    public class SteamSchemaSite
    {
        private const string SITE = "http://api.steampowered.com/IEconItems_440/GetSchema/v0001/?key=01B225FC2C86C2559DBE9B2BFCDC644A&language=en";

        private class Pair
        {
            public int Defindex { get; set; }
            public string Name { get; set; }
        }

        public SteamSchemaSite()
        {
            _idDictionary = new Dictionary<int, string>();
            _stringDictionary = new Dictionary<string, int>();

            Parse(Download());

            StreamReader input = new StreamReader("itemsDictionary.txt");

            while (!input.EndOfStream)
            {
                Pair pair = new Pair
                {
                    Defindex = int.Parse(input.ReadLine()),
                    Name = input.ReadLine()
                };

                if (_idDictionary.ContainsKey(pair.Defindex))
                {
                    _idDictionary.Remove(pair.Defindex);
                    _stringDictionary.Remove(pair.Name);
                }

                _idDictionary.Add(pair.Defindex, pair.Name);
                _stringDictionary.Add(pair.Name, pair.Defindex);
            }
            
            input.Close(); 
        }

        private readonly Dictionary<int, string> _idDictionary;
        private readonly Dictionary<string, int> _stringDictionary;

        public void AddInfo(List<Item> items)
        {
            for (var i = 0; i < items.Count; ++i)
                if (string.IsNullOrEmpty(items[i].FullName))
                {
                    items[i].FullName = _idDictionary[items[i].Defindex];
                    items[i].FullName = QualityWorker.AddQualityToName(ArticalDelite(items[i].FullName),
                        items[i].Quality);
                }
                else
                // BUG not all ids could be found
                {
                    if (_stringDictionary.ContainsKey(items[i].FullName))
                    {
                        items[i].Defindex = _stringDictionary[items[i].FullName];

                    }
                    else
                    {
                        items[i].Defindex = -1;
                    }
                }
        }

        private string ArticalDelite(string s)
        {
            if ((s.StartsWith("The ") || s.StartsWith("the ")))
                s = s.Remove(0, 4);

            return s;
        }

        public StreamReader Download()
        {
            var req = (HttpWebRequest)WebRequest.Create(SITE);
            req.Method = "GET";
            //req.KeepAlive = true;

            try
            {
                return new StreamReader((req.GetResponse() as HttpWebResponse).GetResponseStream(), Encoding.UTF8);
            }
            catch (Exception exception)
            {
                // Warning exception not executed
            }

            return null;
        }

        public void Parse(StreamReader input)
        { 
            var schemaResponse = new SteamSchemaResponse();

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(input.ReadToEnd())))
            {
                var ser = new DataContractJsonSerializer(schemaResponse.GetType(),
                    new DataContractJsonSerializerSettings
                    {
                        UseSimpleDictionaryFormat = true
                    });

                schemaResponse = ser.ReadObject(ms) as SteamSchemaResponse;
            }

            foreach (var t in schemaResponse.Result.Items)
            {
                _idDictionary.Add(t.Defindex, new string(t.Name.ToCharArray()));
                _stringDictionary.Add(new string(t.Name.ToCharArray()), t.Defindex);
            }
        }
    }
}