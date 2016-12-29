using System.Runtime.Serialization;

namespace Steam_monitor.TF2Mart.Json
{
    [DataContract]
    public class Tf2MartResponse
    {
        [DataMember(Name = "currencies")]
        public Currencies Currencies { get; set; }

        [DataMember(Name = "next")]
        public bool Next { get; set; }

        [DataMember(Name = "positions")]
        public Position[] Positions { get; set; }

        [DataMember(Name = "prev")]
        public bool Prev { get; set; }
    }
}