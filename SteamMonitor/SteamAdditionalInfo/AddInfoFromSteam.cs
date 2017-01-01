using System.Collections.Generic;
using Steam_monitor.SteamSchema.Json;

namespace SteamMonitor.SteamAdditionalInfo
{
    internal class AddInfoFromSteam
    {
        public static Additionalnfo GetAddInfoFromSteam(string itemName)
        {
            var additionalInfo = new Additionalnfo();

            additionalInfo = (SteamParcer.Parce(SteamDownload.Download(itemName), itemName));

            return additionalInfo;
        }
    }
}