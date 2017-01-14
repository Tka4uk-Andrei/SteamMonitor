using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using SteamMonitor.SteamAdditionalInfo;
using SteamMonitor.SteamTraderCore;
using SteamMonitor.SteamTraderCore.Steam;
using SteamMonitor.SteamTraderCore.SteamSchema;
using SteamMonitor.SteamTraderCore.TF2Mart;

namespace SteamMonitor
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Genuine.Click += ButtonOnClick;
            Vintege.Click += ButtonOnClick;
            Unusual.Click += ButtonOnClick;
            Community.Click += ButtonOnClick;
            Self_Made.Click += ButtonOnClick;
            Strange.Click += ButtonOnClick;
            Haunted.Click += ButtonOnClick;
            Collectors.Click += ButtonOnClick;
        }

        class TradeCmp<T> : IComparer<T>
            where T : TradeModel
        {
            public int Compare(T x, T y)
            {
                if ((x.Profit * 1000) / x.BuyPrice > (y.Profit * 1000) / y.BuyPrice)
                    return -1;
                if ((x.Profit * 1000) / x.BuyPrice < (y.Profit * 1000) / y.BuyPrice)
                    return 1;

                return 0;
            }
        }

        private void ButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            var k = int.Parse(((Button) sender).Content.ToString());

            var qualities = new List<int>();

            qualities.Add(k);

            var tf2MartSite = new Tf2MartSite(qualities, "tf2Mart.dat");
            var steamSchema = new SteamSchemaSite();

            var steamSite = new SteamSite
                (
                "steam.dat",
                qualities
                );

            steamSchema.AddInfo(tf2MartSite.GetAllItems());

            List<string> notFounItems;
            var outputInfo = ProfitFinder.CompareItems(tf2MartSite, steamSite, out notFounItems);

            var outWriter = new StreamWriter("errors.txt");
            foreach (var i in notFounItems)
                outWriter.WriteLine(i);
            outWriter.Close();

            var cmp = new TradeCmp<TradeModel>();
            outputInfo.Sort(cmp);

            ItemsList.ItemsSource = outputInfo;

            //if (((Button) sender).Content.ToString() != "11" && ((Button)sender).Content.ToString() != "13")
            //{
            //    int kk = 0;
            //    for (var i = 0; i < outputInfo.Count; ++i)
            //    {
            //        if (i == 0 || outputInfo[i].ItemName != outputInfo[i - 1].ItemName)
            //        {
            //            kk++;
            //            Thread.Sleep(1000);
            //            var prom = AddInfoFromSteam.GetAddInfoFromSteam(outputInfo[i].ItemName);
            //            s = prom.SoldCountPerDay + "\t" + prom.Name;
            //            AddText.Text += "\n" + s;
            //        }

            //        if (kk % 10 == 0 && i != 0)
            //            Thread.Sleep(60000);
            //    }
            //}
        }

        private void GetAddInfo(object sender, RoutedEventArgs e)
        {
            // TODO like MVVM
            if (ItemsList.SelectedItems.Count > 0)
            {
                ((TradeModel) ItemsList.SelectedItems[0]).SoldCount =
                    AddInfoFromSteam.GetAddInfoFromSteam(((TradeModel) ItemsList.SelectedItems[0]).ItemName)
                        .SoldCountPerDay.ToString();

                var prom = ItemsList.ItemsSource;
                ItemsList.ItemsSource = null;
                ItemsList.ItemsSource = prom;
            }
        }
    }
}