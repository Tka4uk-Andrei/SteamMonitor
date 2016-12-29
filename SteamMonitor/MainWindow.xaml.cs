using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Steam_monitor;
using Steam_monitor.Steam;
using Steam_monitor.SteamSchema;
using Steam_monitor.TF2Mart;
using Button = System.Windows.Controls.Button;
using MessageBox = System.Windows.MessageBox;

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

            //var qualities = QualityWorker.GetQualities("All");

            var tf2MartSite = new Tf2MartSite(qualities, new Tf2MartDownload(), new TF2MartParser());
            var steamSchema = new SteamSchemaSite();

            var steamSite = new SteamSite
                (
                "steam.dat",
                qualities
                );

            Console.WriteLine();

            steamSchema.AddInfo(tf2MartSite.GetAllItems());

            var outputInfo = ProfitFinder.CompareItems(tf2MartSite, steamSite);

            var s = "";
            foreach (var p in ProfitFinder.CompareItems(tf2MartSite, steamSite))
            {
                s =
                    $"Item {p.ItemName,-55}  -- profit --  {p.Profit,15:### ###.00} руб. price {p.BuyPrice,15:#,#,0.00}";
                TextBlock.Text += "\n" + s;
            }
            Console.WriteLine("".PadLeft(s.Length, '-'));

            //// End of the programm ---
            //Console.ForegroundColor = ConsoleColor.DarkGreen;
            //Console.WriteLine("\n\n{0, 74}\n", "<< -- End of the program -- >>");
            //Console.ReadLine();
            //// --- --- --- --- --- ---
        }
    }
}
