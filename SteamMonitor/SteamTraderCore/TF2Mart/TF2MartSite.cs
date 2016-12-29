using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SteamMonitor.SteamTraderCore;

namespace Steam_monitor.TF2Mart
{
    public class Tf2MartSite : Site
    {
        private const string SITE_NAME = "TF2 Mart";
        private const string INI_FILE_PATH = "tf2_mart_keys.dat";

        private readonly double _buyKeyPrice;
        private readonly double _sellKeyPrice;

        private List<Item> _martItems;

        public Tf2MartSite(List<int> qualities, Tf2MartDownload download, TF2MartParser parser)
        {
            Download = download;
            Parser = parser;

            var iniInfo = new StreamReader(INI_FILE_PATH);
            _sellKeyPrice = Convert.ToDouble(iniInfo.ReadLine());
            _buyKeyPrice = Convert.ToDouble(iniInfo.ReadLine());
            iniInfo.Close();

            UpdateItems(qualities);
        }

        private Tf2MartDownload Download { get; }
        private TF2MartParser Parser { get; }

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
            return _martItems;
        }

        public override List<Item> GetItems(int quality)
        {
            return _martItems.Where(item => item.quality == quality).ToList();
        }

        private void DownloadByOneQuality(int quality)
        {
            foreach (var t in Parser.getItems(Download.Download(quality)))
                _martItems.Add(t);

            //var items = Parser.getItems(Download.Download(1, "d", quality));

            //foreach (var t in items)
            //    _martItems.Add(t);

            while (Parser.NextFlag)
            {
                var items = Parser.getItems(Download.Download(_martItems[_martItems.Count - 1].defindex,
                    _martItems[_martItems.Count - 1].id, quality));

                foreach (var t in items)
                    _martItems.Add(t);
            }

        }

        public void UpdateItems(List<int> qualities)
        {
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.Write("{0, -30}> ", "Загрузка TF2Mart ".PadRight(30, '-'));

            _martItems = new List<Item>();

            foreach (var i in qualities)
                DownloadByOneQuality(i);

            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("окончена");

            //Console.ResetColor();
        }
    }
}