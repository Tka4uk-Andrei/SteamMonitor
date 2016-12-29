namespace Steam_monitor
{
    public class TradeModel
    {
        // TODO delete TradingModel

        // for delete
        public string TradingModel { get; set; }

        public string ItemName { get; set; }

        public double Profit { get; set; }

        public double BuyPrice { get; set; }

        public string BuyPage { get; set; }

        // not used
        public string SellPage { get; set; }
    }
}