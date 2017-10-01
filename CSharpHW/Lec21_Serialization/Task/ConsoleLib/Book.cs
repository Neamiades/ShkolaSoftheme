using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using ProtoBuf;

namespace ConsoleLib
{
    [ProtoContract]
    [DataContract]
    [Serializable]
    [KnownType(typeof(FictionBook))]
    [KnownType(typeof(ScienceBook))]
    [KnownType(typeof(StudyBook))]
    [XmlInclude(typeof(FictionBook))]
    [XmlInclude(typeof(ScienceBook))]
    [XmlInclude(typeof(StudyBook))]
    public class Book
    {
        [ProtoMember(1)]
        [DataMember]
        public string     Name   { get; set; }

        [ProtoMember(2)]
        [DataMember]
        public string     Author { get; set; }

        [ProtoMember(3)]
        [DataMember]
        public BookStatus Status { get; set; }

        [ProtoMember(4)]
        [DataMember]
        public Reader     Holder { get; set; }

        public Book() { }
    }
}
