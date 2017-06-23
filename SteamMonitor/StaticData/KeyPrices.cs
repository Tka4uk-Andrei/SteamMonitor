using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamMonitor.Data;

namespace SteamMonitor.StaticData
{
    class KeyPrices
    {
        private const string STEAM_KEY_FILE_NAME = "steamKey.dat";
        private const string TF2_MART_KEY_FILE_NAME = "tf2MartKey.dat";

        private static KeyPriceData _steamKey;
        private static KeyPriceData _tf2MartKey;

        private static KeyPriceData LoadKeyData(string path)
        {
            var data = new KeyPriceData();
            var keyFile = new StreamReader(path);

            var s = keyFile.ReadLine();
            data.BuyPrice = (s == null) ? 0 : double.Parse(s);

            s = keyFile.ReadLine();
            data.SellPrice = (s == null) ? 0 : double.Parse(s);

            keyFile.Close();

            return data;
        }

        public static KeyPriceData GetSteamKey()
        {
            return _steamKey ?? (_steamKey = LoadKeyData(STEAM_KEY_FILE_NAME));
        }

        public static KeyPriceData GetTf2Mart()
        {
            return _tf2MartKey ?? (_tf2MartKey = LoadKeyData(TF2_MART_KEY_FILE_NAME));
        }
    }
}
