using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using SteamMonitor.StaticData;
using SteamMonitor.StaticData.Cookies;
using Steam_monitor.SteamSchema.Json;

namespace SteamMonitor.SteamTraderCore.Steam
{
    public class SteamSite : Site
    {
        private const string SITE_NAME = "SteamCommunity";
        
        private readonly double _buyKeyPrice;
        private readonly CookieContainer _cookieContainer;
        private readonly GetSteamItemsRequest _download;
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
            _download = new GetSteamItemsRequest();
            _parser = new SteamParser();

            _cookieContainer = SteamCookies.GetStatus().GetCookieContainer();

            _sellKeyPrice = KeyPrices.GetSteamKey().SellPrice;
            _buyKeyPrice = KeyPrices.GetSteamKey().BuyPrice;

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
            return _steamItems.Where(item => item.Quality == quality).ToList();
        }

        public void Download(int quality)
        {
            ClearItemsList(quality);

            _download.StartCount = 0;
            do
            {
                _steamItems.AddRange(_parser.GetItems(_download.Download(_cookieContainer, quality)));
                _download.StartCount += 100;
            } while (_download.StartCount <= _parser.MaxPage);
        }

        public void ClearItemsList(int quality)
        {
            for (var i = 0; i < _steamItems.Count; ++i)
            {
                if (_steamItems[i].Quality != quality) continue;

                _steamItems.RemoveAt(i);
                i--;
            }
        }
    }
}