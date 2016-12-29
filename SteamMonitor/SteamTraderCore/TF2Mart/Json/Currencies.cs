using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Steam_monitor.TF2Mart.Json
{
    [DataContract]
    public class Currencies
    {
        [DataMember(Name = "ref")]
        public Ref Ref { get; set; }

        [DataMember(Name = "key")]
        public Key Key { get; set; }
    }
}
