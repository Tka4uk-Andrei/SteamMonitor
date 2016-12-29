using System.Runtime.Serialization;

namespace Steam_monitor.Steam.Json
{
    [DataContract]
    public class AppData
    {
        [DataMember(Name = "appid")]
        public int AppId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "link")]
        public string Link { get; set; }
    }
}