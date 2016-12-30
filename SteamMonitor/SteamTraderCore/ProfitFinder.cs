using System;
using System.Collections.Generic;
using SteamMonitor.SteamTraderCore;

namespace Steam_monitor
{
    public class ProfitFinder
    {
        // покупаем на а продаём на б
        public static List<TradeModel> CompareItems(Site a, Site b)
        {
            var trades = new List<TradeModel>();

            for (int i = 0; i < a.GetAllItems().Count; ++i)
            {
                var itemA = a.GetAllItems()[i];
                var itemsB = b.GetAllItems();

                int p = FindItem(ref itemA, ref itemsB);

                var itemB = itemsB[p];

                if (itemA.fullName != itemB.fullName)
                    PrintNotFound(itemA);
                else if ((itemA.buyPrice / a.GetSellKeyPrice() * b.GetBuyKeyPrice()) < itemB.sellPrice)
                {
                    trades.Add(new TradeModel
                    {
                        BuyPrice = itemA.buyPrice,
                        Profit = itemB.sellPrice - b.GetBuyKeyPrice() / a.GetSellKeyPrice() * itemA.buyPrice,
                        ItemName = itemA.fullName
                    });
                }
            }

            Console.WriteLine();
            Console.WriteLine();

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

        private static void PrintNotFound(Item item)
        {
            var s =
                $"|| {"\"" + item.fullName + "\"",-55} || with defindex: {item.defindex,10:#,#,#} couldn't be found";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("".PadLeft(s.Length, '-'));
            Console.WriteLine(s);
            Console.WriteLine("".PadLeft(s.Length, '-'));
            Console.ResetColor();
        }
    }
}