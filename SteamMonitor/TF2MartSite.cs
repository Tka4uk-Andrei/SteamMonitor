using System.Collections.Generic;
using System.Linq;
using System.Net;
using SteamMonitor.Requests.TF2Mart;
using SteamMonitor.StaticData;

namespace SteamMonitor.SteamTraderCore.TF2Mart
{
    public class Tf2MartSite : Site
    {
        private const string SITE_NAME = "TF2Mart";
        private const string INI_FILE_PATH = SITE_NAME + ".dat";

        private readonly double _buyKeyPrice;
        private readonly CookieContainer _cookieContainer;
        private readonly Tf2MartDownload _download;

        private readonly List<Item> _martItems;
        private readonly Tf2MartParser _parser;
        private readonly double _sellKeyPrice;

        public Tf2MartSite(List<int> qualities, string cookiePath)
        {
            _download = new Tf2MartDownload();
            _parser = new Tf2MartParser();

            _cookieContainer = CookieProvider.GetProvider().GetTf2MartContainer();

            _sellKeyPrice = KeyPrices.GetTf2Mart().SellPrice;
            _buyKeyPrice = KeyPrices.GetTf2Mart().BuyPrice;

            _martItems = new List<Item>();

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
            return _martItems;
        }

        public override List<Item> GetItems(int quality)
        {
            return _martItems.Where(item => item.Quality == quality).ToList();
        }

        public void Download(int quality)
        {
            ClearItemsList(quality);

            foreach (var t in _parser.GetItems(_download.Download(_cookieContainer, quality)))
                _martItems.Add(t);

            while (_parser.NextFlag)
                foreach (var t in
                    _parser.GetItems(_download.Download
                        (_cookieContainer, 
                         quality,
                         _martItems[_martItems.Count - 1].Defindex, 
                         _martItems[_martItems.Count - 1].Id)))
                    _martItems.Add(t);
        }

        private void ClearItemsList(int quality)
        {
            for (var i = 0; i < _martItems.Count; ++i)
            {
                if (_martItems[i].Quality != quality) continue;

                _martItems.RemoveAt(i);
                i--;
            }
        }
    }
}