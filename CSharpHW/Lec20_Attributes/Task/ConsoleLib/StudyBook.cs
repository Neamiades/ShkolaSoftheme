using System;
using System.Runtime.Serialization;

namespace ConsoleLib
{
    [DataContract]
    [Serializable]
    class StudyBook : Book
    {
        [DataMember]
        public string Subject { get; set; }
    }
}
