using System;
using System.ComponentModel.DataAnnotations;
using ProtoBuf;

namespace ConsoleLib
{
    [ProtoContract]
    [Serializable]
    public class Reader
    {
        [ProtoMember(1)]
        [Required]
        public string       Name      { get; set; }

        [ProtoMember(2)]
        public ReaderGender Gender    { get; set; }

        [ProtoMember(3)]
        [Required]
        [StringLength(2, ErrorMessage = "Signature must contain only two letters")]
        public string       Signature { get; set; }

        public Reader() { }
    }
}
