using System;
using System.Collections.Generic;
using System.Windows;
using SteamMonitor.SteamTraderCore;
using SteamMonitor.SteamTraderCore.Steam;
using SteamMonitor.SteamTraderCore.SteamSchema;
using SteamMonitor.SteamTraderCore.TF2Mart;
using Steam_monitor;
using Steam_monitor.SteamSchema;
using Button = System.Windows.Controls.Button;

namespace SteamMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Genuine.Click +=ButtonOnClick;
            Vintege.Click += ButtonOnClick;
            Unusual.Click += ButtonOnClick;
            Community.Click += ButtonOnClick;
            Self_Made.Click += ButtonOnClick;
            Strange.Click += ButtonOnClick;
            Haunted.Click += ButtonOnClick;
            Collectors.Click += ButtonOnClick;

        }

        private void ButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            int k = Int32.Parse(((Button)sender).Content.ToString());

            var qualities = new List<int>();

            qualities.Add(k);

            var tf2MartSite = new Tf2MartSite(qualities, "tf2Mart.dat");
            var steamSchema = new SteamSchemaSite();

            var steamSite = new SteamSite
                (
                "steam.dat",
                qualities
                );

            Console.WriteLine();

            steamSchema.AddInfo(tf2MartSite.GetAllItems());

            List<string> notFounItems;
            var outputInfo = ProfitFinder.CompareItems(tf2MartSite, steamSite, out notFounItems);

            var s = "";
            foreach (var p in outputInfo)
            {
                s =
                    $"Item {p.ItemName,-55}  -- profit --  {p.Profit,15:### ###.00} руб. price {p.BuyPrice,15:#,#,0.00}";
                TextBlock.Text += "\n" + s;
            }
            Console.WriteLine("".PadLeft(s.Length, '-'));
        }
    }
}
