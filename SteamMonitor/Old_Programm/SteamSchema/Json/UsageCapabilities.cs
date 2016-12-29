using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class UsageCapabilities
    {
        [DataMember(Name = "nameable")]
        public bool Nameable { get; set; }

        [DataMember(Name = "decodable")]
        public bool Decodable { get; set; }

        [DataMember(Name = "paintable")]
        public bool Paintable { get; set; }

        [DataMember(Name = "can_customize_texture")]
        public bool CanCustomizeTexture { get; set; }

        [DataMember(Name = "can_gift_wrap")]
        public bool CanGiftWrap { get; set; }

        [DataMember(Name = "paintable_team_colors")]
        public bool PaintableTeamColors { get; set; }

        [DataMember(Name = "can_strangify")]
        public bool CanStrangify { get; set; }

        [DataMember(Name = "can_killstreakify")]
        public bool CanKillstreakify { get; set; }

        [DataMember(Name = "duck_upgradable")]
        public bool DuckUpgradable { get; set; }

        [DataMember(Name = "strange_parts")]
        public bool StrangeParts { get; set; }

        [DataMember(Name = "can_card_upgrade")]
        public bool CanCardUpgrade { get; set; }

        [DataMember(Name = "can_spell_page")]
        public bool CanSpellPage { get; set; }

        [DataMember(Name = "can_consume")]
        public bool CanConsume { get; set; }
    }
}