using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Steam_monitor;

namespace SteamMonitor.SteamTraderCore.Steam
{
    public class SteamSite : Site
    {
        private const string SITE_NAME = "SteamCommunity";
        private const string INI_FILE_PATH = SITE_NAME + ".dat";

        private readonly double _buyKeyPrice;
        private readonly double _sellKeyPrice;

        private List<Item> _steamItems;

        private CookieContainer

        public SteamSite(string cookiePath, List<int> qualities)
        {
            download = new SteamDownload();
            parser = new SteamParser();

            var iniInfo = new StreamReader(INI_FILE_PATH);
            _sellKeyPrice = Convert.ToDouble(iniInfo.ReadLine());
            _buyKeyPrice = Convert.ToDouble(iniInfo.ReadLine());
            iniInfo.Close();

            _steamItems = new List<Item>();

            InitializeDownload(qualities, cookiePath);
        }

        private SteamDownload download { get; }
        private SteamParser parser { get; }

        public override string GetSiteName()
        {
            return SITE_NAME;
        }

        public override double GetSellKeyPrice()
        {
            return _sellKeyPrice;
        }

        public override double GetBuyKeyPrice()
        {
            return _buyKeyPrice;
        }

        public override List<Item> GetAllItems()
        {
            return _steamItems;
        }

        public override List<Item> GetItems(int quality)
        {
            return _steamItems.Where(item => item.quality == quality).ToList();
        }

        public void InitializeDownload(List<int> qualities, string cookiePath)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0, -30}> ", "Загрузка Steam Items ".PadRight(30, '-'));

            _steamItems = new List<Item>();

            foreach (var quality in qualities)
            {
                download.StartCount = 0;
                do
                {
                    _steamItems.AddRange(parser.getItems(download.Download(cookiePath, quality)));
                    download.StartCount += 100;
                } while (download.StartCount <= parser.maxPage);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("окончена");

            Console.ResetColor();
        }
    }
}