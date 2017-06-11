using System;
using System.Collections.Generic;

namespace SteamMonitor.SteamMarketItems
{
    public class ItemInfo
    {
        public ItemInfo()
        {
            Name = "none";
            ListingId = "none";
            AssetId = "none";
            Price = int.MaxValue;
            CountOnSell = 1;
        }

        public string Name { set; get; }
        public string ListingId { set; get; }
        public string AssetId { set; get; }
        public int Price { set; get; }
        public int CountOnSell { set; get; }
    }

    public class ItemComp<TItemInfo> : IComparer<TItemInfo>
        where TItemInfo : ItemInfo

    {
        public int Compare(TItemInfo x, TItemInfo y)
        {
            return String.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }
}