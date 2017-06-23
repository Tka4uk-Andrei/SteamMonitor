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

        public static string AddQualityToName(string name, int quality)
        {
            if (IdDictionary.ContainsKey(quality))
                return IdDictionary[quality] + " " + name;

            return name;
        }
    }
}