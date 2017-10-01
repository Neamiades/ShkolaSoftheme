using System;
using System.Runtime.Serialization;
using ProtoBuf;

namespace ConsoleLib
{
    [DataContract]
    [Serializable]
    [ProtoContract]
    public class FictionBook : Book
    {
        [ProtoMember(1)]
        [DataMember]
        public string Genre { get; set; }

        public FictionBook() { }
    }
}
