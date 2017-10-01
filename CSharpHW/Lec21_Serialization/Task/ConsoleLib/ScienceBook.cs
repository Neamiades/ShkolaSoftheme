using System;
using System.Runtime.Serialization;
using ProtoBuf;

namespace ConsoleLib
{
    [DataContract]
    [Serializable]
    [ProtoContract]
    [OnlyForViewing]
    public class ScienceBook : Book
    {
        [ProtoMember(1)]
        [DataMember]
        public string ResearchTheme { get; set; }

        public ScienceBook() { }
    }
}
