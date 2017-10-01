using System;
using System.Runtime.Serialization;

namespace ConsoleLib
{
    [DataContract]
    [Serializable]
    [OnlyForViewing]
    class ScienceBook : Book
    {
        [DataMember]
        public string ResearchTheme { get; set; }
    }
}
