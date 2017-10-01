using System;
using System.Runtime.Serialization;

namespace ConsoleLib
{
    [DataContract]
    [Serializable]
    abstract class Book
    {
        [DataMember]
        public string     Name   { get; set; }

        [DataMember]
        public string     Author { get; set; }

        [DataMember]
        public BookStatus Status { get; set; }

        [DataMember]
        public Reader     Holder { get; set; }
    }
}
