using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Steam_monitor
{
    static class CookieWorker
    {
        public static List<Cookie> LoadFile(string fileName)
        {
            StreamReader cookieReader = new StreamReader(fileName);

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
    }
}
