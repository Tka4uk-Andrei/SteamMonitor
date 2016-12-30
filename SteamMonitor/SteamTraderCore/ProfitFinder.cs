using System;
using System.Collections.Generic;
using Steam_monitor;

namespace SteamMonitor.SteamTraderCore
{
    public class ProfitFinder
    {
        // покупаем на а продаём на б
        public static List<TradeModel> CompareItems(Site a, Site b, out List<string> errorLog)
        {
            var trades = new List<TradeModel>();
            errorLog = new List<string>();

            for (int i = 0; i < a.GetAllItems().Count; ++i)
            {
                var itemA = a.GetAllItems()[i];
                var itemsB = b.GetAllItems();

                int foundItemBIndex = FindItem(ref itemA, ref itemsB);
                var itemB = itemsB[foundItemBIndex];

                if (itemA.fullName != itemB.fullName)
                {
                    string notFoundItem = itemA.fullName + "\t" + itemA.defindex;
                    errorLog.Add(notFoundItem);
                }
                else if ((itemA.buyPrice/a.GetSellKeyPrice()*b.GetBuyKeyPrice()) < itemB.sellPrice)
                {
                    trades.Add(new TradeModel
                    {
                        BuyPrice = itemA.buyPrice,
                        Profit = itemB.sellPrice - b.GetBuyKeyPrice()/a.GetSellKeyPrice()*itemA.buyPrice,
                        ItemName = itemA.fullName,
                        BuyPage = a.GetSiteName(),
                        SellPage = b.GetSiteName()
                    });
                }
            }

            return trades;
        }

        private static int FindItem(ref Item item, ref List<Item> items)
        {
            var i = 0;

            while (i < items.Count && item.fullName != items[i].fullName)
                ++i;

            if (i == items.Count)
            {
                i = 0;
                while (i < items.Count && 
                    "Strange " + item.fullName != items[i].fullName && item.fullName != "Strange " + items[i].fullName)
                    ++i;
            }

            if (i == items.Count)
                i--;
            if ("Strange " + item.fullName == items[i].fullName)
                item.fullName = "Strange " + item.fullName;
            if (item.fullName == "Strange " + items[i].fullName)
                items[i].fullName = "Strange " + items[i].fullName;

            return i;
        }
    }
}