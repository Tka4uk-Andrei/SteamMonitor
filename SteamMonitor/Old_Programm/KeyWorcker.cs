using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam_monitor
{
    // EDIT file load

    static class KeyWorcker
    {
        public static double GetBuyPrice(string path)
        {
            StreamReader cookieReader = new StreamReader(path);

            var a = double.Parse(cookieReader.ReadLine());

            cookieReader.Close();

            return a;
        }

        public static double GetSellPrice(string path)
        {
            StreamReader cookieReader = new StreamReader(path);

            cookieReader.ReadLine();

            double a;
            double.TryParse(cookieReader.ReadLine(), out a);

            cookieReader.Close();

            return a;
        }
    }
}
