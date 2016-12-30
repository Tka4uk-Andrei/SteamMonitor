using System.Runtime.Serialization;

namespace Steam_monitor.SteamSchema.Json
{
    [DataContract]
    public class AttributeControlledAttachedParticles
    {
        [DataMember(Name = "system")]
        public string System { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "attach_to_rootbone")]
        public bool AttachToRootbone { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "attachment")]
        public string Attachment { get; set; }
    }
}