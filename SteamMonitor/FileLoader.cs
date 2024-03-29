﻿using System.Collections.Generic;
using System.IO;
using System.Net;

//
// maybe we need to rename it 
//

namespace SteamMonitor.SteamTraderCore
{
    internal class FileLoader
    {
        // TODO rename varibles
        public static class KeyWorcker
        {
            public static double GetBuyPrice(string path)
            {
                var cookieReader = new StreamReader(path);

                var a = double.Parse(cookieReader.ReadLine());

                cookieReader.Close();

                return a;
            }

            public static double GetSellPrice(string path)
            {
                var cookieReader = new StreamReader(path);

                cookieReader.ReadLine();

                double a;
                double.TryParse(cookieReader.ReadLine(), out a);

                cookieReader.Close();

                return a;
            }
        }

        public static class CookieWorker
        {
            public static List<Cookie> LoadFile(string fileName)
            {
                var cookieReader = new StreamReader(fileName);

                var cookies = new List<Cookie>();
                while (!cookieReader.EndOfStream)
                {
                    cookies.Add(new Cookie(
                        cookieReader.ReadLine(),
                        cookieReader.ReadLine(),
                        cookieReader.ReadLine(),
                        cookieReader.ReadLine())
                        );
                }
                cookieReader.Close();

                return cookies;
            }

            public static CookieContainer LoadCookieContainer(string fileName)
            {
                var p = LoadFile(fileName);

                var r = new CookieContainer();

                foreach (var i in p)
                {
                    r.Add(i);
                }

                return r;
            }
        }
    }
}