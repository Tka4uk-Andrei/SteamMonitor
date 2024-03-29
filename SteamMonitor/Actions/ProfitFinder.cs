﻿using System;
using System.Collections.Generic;

namespace SteamMonitor.SteamTraderCore
{
    public class ProfitFinder
    {
        // покупаем на а продаём на б
        public static List<TradeModel> CompareItems(Site a, Site b, out List<string> errorLog)
        {
            var trades = new List<TradeModel>();
            errorLog = new List<string>();

            for (var i = 0; i < a.GetAllItems().Count; ++i)
            {
                var itemA = a.GetAllItems()[i];
                var itemsB = b.GetAllItems();

                var foundItemBIndex = FindItem(ref itemA, ref itemsB);
                var itemB = itemsB[foundItemBIndex];

                // todo there is a problem with item search (guess). Touches strange items.
                if (itemA.FullName != itemB.FullName)
                {
                    var notFoundItem = itemA.FullName + "\t" + itemA.Defindex;
                    errorLog.Add(notFoundItem);
                }
                else if ((itemA.BuyPrice/a.GetSellKeyPrice()*b.GetBuyKeyPrice()) < itemB.SellPrice)
                {
                    trades.Add(new TradeModel
                    {
                        BuyPrice = Math.Round(itemA.BuyPrice * 100.0) / 100.0,
                        Profit = Math.Round((itemB.SellPrice - b.GetBuyKeyPrice()/a.GetSellKeyPrice()*itemA.BuyPrice) * 100.0) / 100.0,
                        ItemName = itemA.FullName,
                        BuyPage = a.GetSiteName(),
                        SellPage = b.GetSiteName(),
                        SoldCount = ""
                    });
                }
            }

            return trades;
        }

        // returns position of item in items list
        private static int FindItem(ref Item item, ref List<Item> items)
        {
            var i = 0;

            while (i < items.Count && item.FullName != items[i].FullName)
                ++i;

            if (i == items.Count)
            {
                i = 0;
                while (i < items.Count &&
                       "Strange " + item.FullName != items[i].FullName &&
                       item.FullName != "Strange " + items[i].FullName)
                    ++i;
            }

            if (i == items.Count)
                i--;
            if ("Strange " + item.FullName == items[i].FullName)
                item.FullName = "Strange " + item.FullName;
            if (item.FullName == "Strange " + items[i].FullName)
                items[i].FullName = "Strange " + items[i].FullName;

            return i;
        }
    }
}