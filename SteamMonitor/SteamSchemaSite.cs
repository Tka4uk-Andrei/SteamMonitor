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
        // todo rename valibules
        private const string SITE_1 = "http://api.steampowered.com/IEconItems_440/GetSchemaItems/v0001/?key=01B225FC2C86C2559DBE9B2BFCDC644A&language=en";
        private const string SITE_2 = "http://api.steampowered.com/IEconItems_440/GetSchemaItems/v0001/?key=01B225FC2C86C2559DBE9B2BFCDC644A&language=en&start={0}";

        private class Pair
        {
            public int Defindex { get; set; }
            public string Name { get; set; }
        }

        public SteamSchemaSite()
        {
            _idDictionary = new Dictionary<int, string>();
            _stringDictionary = new Dictionary<string, int>();

            int startVal = 0;
            Parse(Download(), out startVal);

            bool endFlag = false;
            while (!endFlag)
            {
                Parse(Download(startVal), out startVal);
                endFlag = (startVal == 0);
            }

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
                // todo bug fix. not all ids could be found
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
            var req = (HttpWebRequest)WebRequest.Create(SITE_1);
            req.Method = "GET";

            try
            {
                return new StreamReader((req.GetResponse() as HttpWebResponse).GetResponseStream(), Encoding.UTF8);
            }
            catch (Exception exception)
            {
                // todo exception not executed
            }

            return null;
        }

        public StreamReader Download(int startId)
        {
            var req = (HttpWebRequest)WebRequest.Create(string.Format(SITE_2, startId));
            req.Method = "GET";

            try
            {
                return new StreamReader((req.GetResponse() as HttpWebResponse).GetResponseStream(), Encoding.UTF8);
            }
            catch (Exception exception)
            {
                // todo exception not executed
            }

            return null;
        }

        public void Parse(StreamReader input, out int nextVal)
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

            nextVal = schemaResponse.Result.Next;

            foreach (var t in schemaResponse.Result.Items)
            {
                _idDictionary.Add(t.Defindex, new string(t.Name.ToCharArray()));
                _stringDictionary.Add(new string(t.Name.ToCharArray()), t.Defindex);
            }
        }
    }
}