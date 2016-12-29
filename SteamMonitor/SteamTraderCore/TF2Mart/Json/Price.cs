using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Steam_monitor.TF2Mart.Json
{
    [DataContract]
    public class Price
    {
        [DataMember(Name = "buy")]
        public int Buy { get; set; }

        [DataMember(Name = "sell")]
        public int Sell { get; set; }
    }
}
