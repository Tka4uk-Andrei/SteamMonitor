﻿using System.Collections.Generic;

namespace SteamMonitor.SteamTraderCore
{
    public abstract class Site
    {
        public abstract string GetSiteName();
        public abstract double GetSellKeyPrice();
        public abstract double GetBuyKeyPrice();
        public abstract List<Item> GetAllItems();
        public abstract List<Item> GetItems(int quality);
    }
}