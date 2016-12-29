using System.IO;
using System.Net;

namespace SteamMonitor.SteamTraderCore
{
    public interface IDownload
    {
        StreamReader Download(CookieContainer cookies, int quality);
    }
}