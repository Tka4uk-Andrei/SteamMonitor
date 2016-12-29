﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Steam_monitor.SteamSchema
{
    public class SteamSchemaSite
    {
        private const string SITE = "http://api.steampowered.com/IEconItems_440/GetSchema/v0001/?key=C8CC97BC3362F59E3A7C115F7D965D69&language=en";

        public SteamSchemaSite()
        {
            _idDictionary = new Dictionary<int, string>();
            _stringDictionary = new Dictionary<string, int>();

            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.Write("{0, -30}> ", "Загрузка SteamSchema ".PadRight(30, '-'));

            Parse(Download());

            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("окончена");

            //Console.ResetColor();
        }

        private readonly Dictionary<int, string> _idDictionary;
        private readonly Dictionary<string, int> _stringDictionary;

        public void AddInfo(List<Item> items)
        {
            for (var i = 0; i < items.Count; ++i)
                if (string.IsNullOrEmpty(items[i].fullName))
                {
                    items[i].fullName = _idDictionary[items[i].defindex];

                    switch (items[i].defindex)
                    {
                        case 935:
                            items[i].fullName = "Voodoo JuJu (Slight Return)";
                            break;
                        case 5617:
                            items[i].fullName = "Voodoo-Cursed Scout Soul";
                            break;
                        case 5618:
                            items[i].fullName = "Voodoo-Cursed Soldier Soul";
                            break;
                        case 5619:
                            items[i].fullName = "Voodoo-Cursed Heavy Soul";
                            break;
                        case 5620:
                            items[i].fullName = "Voodoo-Cursed Demoman Soul";
                            break;
                        case 5621:
                            items[i].fullName = "Voodoo-Cursed Engineer Soul";
                            break;
                        case 5622:
                            items[i].fullName = "Voodoo-Cursed Medic Soul";
                            break;
                        case 5623:
                            items[i].fullName = "Voodoo-Cursed Spy Soul";
                            break;
                        case 5624:
                            items[i].fullName = "Voodoo-Cursed Pyro Soul";
                            break;
                        case 5625:
                            items[i].fullName = "Voodoo-Cursed Sniper Soul";
                            break;
                        case 30519:
                            items[i].fullName = "Mannhattan Project";
                            break;
                        case 30536:
                            items[i].fullName = "Li'l Dutchman";
                            break;
                    }

                    items[i].fullName = QualityWorker.AddQualityToName(ArticalDelite(items[i].fullName), items[i].quality);
                }
                else
                    // BUG not all ids could be found
                    items[i].defindex = _stringDictionary[items[i].fullName];
        }

        private string ArticalDelite(string s)
        {
            if ((s.StartsWith("The ") || s.StartsWith("the ")))
                s = s.Remove(0, 4);

            return s;
        }

        private HttpWebRequest generateRequest()
        {
            var req = (HttpWebRequest)WebRequest.Create(SITE);

            req.Method = "GET";
            req.KeepAlive = true;

            return req;
        }

        public StreamReader Download()
        {
            var req = generateRequest();

            try
            {
                var resp = (HttpWebResponse) req.GetResponse();
                return new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
            }
            catch (Exception exception)
            {
                //Console.WriteLine("Ошибка при загрузке информации с SteamSchema (TF2Mart)");
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("{0, 30}", exception.Message + "\n");
                //Console.ReadLine();
                //Environment.Exit(0);
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