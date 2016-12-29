using System.Collections.Generic;
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
        private readonly CookieContainer _cookieContainer;
        private readonly SteamDownload _download;
        private readonly SteamParser _parser;
        private readonly double _sellKeyPrice;
        private readonly List<Item> _steamItems;

        /// <summary>
        ///     main constructor what gets items by given qualities
        /// </summary>
        /// <param name="cookiePath"></param>
        /// <param name="qualities">qualities what will be download</param>
        public SteamSite(string cookiePath, List<int> qualities)
        {
            _download = new SteamDownload();
            _parser = new SteamParser();

            _cookieContainer = FileLoader.CookieWorker.LoadCookieContainer(cookiePath);

            _sellKeyPrice = FileLoader.KeyWorcker.GetSellPrice(INI_FILE_PATH);
            _buyKeyPrice = FileLoader.KeyWorcker.GetBuyPrice(INI_FILE_PATH);

            _steamItems = new List<Item>();

            foreach (var quality in qualities)
                Download(quality);
        }

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

        public void Download(int quality)
        {
            _download.StartCount = 0;
            do
            {
                _steamItems.AddRange(_parser.getItems(_download.Download(_cookieContainer, quality)));
                _download.StartCount += 100;
            } while (_download.StartCount <= _parser.maxPage);
        }
    }
}