using System;
using System.Runtime.Serialization;
using ProtoBuf;

namespace ConsoleLib
{
    [DataContract]
    [Serializable]
    [ProtoContract]
    public class StudyBook : Book
    {
        [ProtoMember(1)]
        [DataMember]
        public string Subject { get; set; }

        public StudyBook() { }
    }
}
