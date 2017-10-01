using System;
using System.Runtime.Serialization;

namespace ConsoleLib
{
    [DataContract]
    [Serializable]
    class FictionBook : Book
    {
        [DataMember]
        public string Genre { get; set; }
    }
}
