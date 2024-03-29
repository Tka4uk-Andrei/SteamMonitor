﻿using System.Runtime.Serialization;

namespace SteamMonitor.SteamTraderCore.TF2Mart.Json
{
    [DataContract]
    public class Position
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "slot")]
        public object Slot { get; set; }

        [DataMember(Name = "appId")]
        public int AppId { get; set; }

        [DataMember(Name = "price")]
        public Price Price { get; set; }

        [DataMember(Name = "classes")]
        public string[] Classes { get; set; }

        [DataMember(Name = "quality")]
        public int Quality { get; set; }

        [DataMember(Name = "defindex")]
        public int Defindex { get; set; }

        [DataMember(Name = "quantity")]
        public Quantity Quantity { get; set; }

        [DataMember(Name = "craftable")]
        public bool Craftable { get; set; }

        [DataMember(Name = "paint")]
        public int Paint { get; set; }

        [DataMember(Name = "australium")]
        public bool Australium { get; set; }

        [DataMember(Name = "strangeParts")]
        public object StrangeParts { get; set; }

        [DataMember(Name = "killstreak")]
        public object Killstreak { get; set; }
    }
}
