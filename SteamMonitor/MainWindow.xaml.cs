using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
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

            var s = "";
            foreach (var p in outputInfo)
            {
                s =
                    $"Item {p.ItemName,-55}  -- profit --  {p.Profit,15:### ###.00} руб. price {p.BuyPrice,15:#,#,0.00}";
                TextBlock.Text += "\n" + s;
            }
            Console.WriteLine("".PadLeft(s.Length, '-'));


            for (var i = 0; i < outputInfo.Count; ++i)
            {
                if (i == 0 || outputInfo[i].ItemName != outputInfo[i - 1].ItemName)
                {
                    var prom = AddInfoFromSteam.GetAddInfoFromSteam(outputInfo[i].ItemName);
                    s = prom.SoldCountPerDay + "\t" + prom.Name;
                    AddText.Text += "\n" + s;
                }

                if (i%30 == 0 && i != 0)
                    Thread.Sleep(60000);
            }
        }
    }
}