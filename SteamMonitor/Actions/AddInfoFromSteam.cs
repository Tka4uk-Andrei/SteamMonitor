using SteamMonitor.SteamAdditionalInfo;

namespace SteamMonitor.Actions
{
    internal class AddInfoFromSteam
    {
        public static Additionalnfo GetAddInfoFromSteam(string itemName)
        {
            var additionalInfo = (SteamParcer.Parce(SteamDownload.Download(itemName), itemName));

            return additionalInfo;
        }
    }
}