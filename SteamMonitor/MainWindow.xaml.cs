﻿using System.Collections.Generic;
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
        private List<TradeModel> _profitItems;

        public MainWindow()
        {
            InitializeComponent();
            Select.IsEnabled = false;


            Genuine.Click += ButtonOnClick;
            Vintege.Click += ButtonOnClick;
            Unusual.Click += ButtonOnClick;
            Community.Click += ButtonOnClick;
            Self_Made.Click += ButtonOnClick;
            Strange.Click += ButtonOnClick;
            Haunted.Click += ButtonOnClick;
            Collectors.Click += ButtonOnClick;

            Select.Click += SelectClick;
        }

        private void ButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            Select.IsEnabled = false;

            var k = int.Parse(((Button) sender).Content.ToString());

            var qualities = new List<int> {k};

            var tf2MartSite = new Tf2MartSite(qualities, "tf2Mart.dat");
            var steamSchema = new SteamSchemaSite();
            var steamSite = new SteamSite("steam.dat", qualities);

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
            _profitItems = new List<TradeModel>();
            _profitItems = outputInfo;

            Select.IsEnabled = true;
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

        private void SelectClick(object sender, RoutedEventArgs routedEventArgs)
        {
            var selectedItems = new List<TradeModel>();

            for (var i = 0; i < _profitItems.Count; ++i)
            {
                if (_profitItems[i].BuyPrice <= double.Parse(MaxPriceBox.Text) || MaxPriceBox.Text.Equals("0"))
                    selectedItems.Add(_profitItems[i]);
            }

            ItemsList.ItemsSource = selectedItems;
        }

        private class TradeCmp<T> : IComparer<T>
            where T : TradeModel
        {
            public int Compare(T x, T y)
            {
                if ((x.Profit*1000)/x.BuyPrice > (y.Profit*1000)/y.BuyPrice)
                    return -1;
                if ((x.Profit*1000)/x.BuyPrice < (y.Profit*1000)/y.BuyPrice)
                    return 1;

                return 0;
            }
        }
    }
}