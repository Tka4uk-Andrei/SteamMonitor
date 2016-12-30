using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class StringLookups
    {
        [DataMember(Name = "table_name")]
        public string TableName { get; set; }

        [DataMember(Name = "strings")]
        public String[] Strings { get; set; }
    }
}