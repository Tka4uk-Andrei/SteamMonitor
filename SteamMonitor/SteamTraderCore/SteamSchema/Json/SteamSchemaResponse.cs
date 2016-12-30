using System.Runtime.Serialization;
using Steam_monitor.SteamSchema.Json;

namespace Steam_monitor.SteamSchema
{
    [DataContract]
    public class SteamSchemaResponse
    {
        [DataMember(Name = "result")]
        public Result Result { get; set; }
    }
}