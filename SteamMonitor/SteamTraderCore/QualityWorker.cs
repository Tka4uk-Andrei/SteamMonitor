using System;
using System.Collections.Generic;

namespace SteamMonitor.SteamTraderCore
{
    internal static class QualityWorker
    {
        public static readonly Dictionary<int, string> IdDictionary = new Dictionary<int, string>
        {
            {1, "Genuine"},
            {3, "Vintage"},
            {5, "Unusual"},
            {7, "Community"},
            {9, "Self-Made"},
            {11, "Strange"},
            {13, "Haunted"},
            {14, "Collector's"}
        };

        public static readonly Dictionary<string, int> StringDictionary = new Dictionary<string, int>
        {
            {"Genuine", 1},
            {"Vintage", 3},
            {"Unusual", 5},
            {"Community", 7},
            {"Self-Made", 9},
            {"Strange", 11},
            {"Haunted", 13},
            {"Collector's", 14}
        };


        public static List<int> GetQualities(string siteName)
        {
            //Warning not all qualities could be added in one list

            var qualities = new List<int>();

            Console.WriteLine("Choose qualities for {0}", siteName);
            Console.WriteLine("".PadRight(35, '-'));

            foreach (var t in IdDictionary)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0, -4}---> {1}", (t.Key + " ").PadRight(4, '-'), t.Value);
                Console.ResetColor();

                Console.WriteLine("".PadRight(35, '-'));
            }
            Console.WriteLine("{0, -4}---> {1}", "0 ".PadRight(4, '-'), "End of transition");
            Console.WriteLine("".PadRight(35, '-'));

            var flag = true;
            do
            {
                var sub = "";
                foreach (var t in Console.ReadLine())
                    if (t == ' ')
                    {
                        int p;
                        if (int.TryParse(sub, out p) && IdDictionary.ContainsKey(p) && !qualities.Contains(p))
                            qualities.Add(p);
                        else if (sub == "0")
                        {
                            flag = false;
                            break;
                        }
                        sub = "";
                    }
                    else
                        sub += t;

                if (sub == "0")
                    flag = false;

            } while (flag);

            return qualities;
        }

        public static string AddQualityToName(string name, int quality)
        {
            if (IdDictionary.ContainsKey(quality))
                return IdDictionary[quality] + " " + name;

            return name;
        }
    }
}