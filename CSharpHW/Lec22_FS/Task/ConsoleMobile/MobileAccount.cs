using System;
using static System.Console;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using ProtoBuf;
using TelNum = System.String;
using AbonentName = System.String;

namespace ConsoleMobile
{
    [ProtoContract]
    [DataContract]
    [KnownType(typeof(Regex))]
    class MobileAccount
    {
        [DataMember]
        [ProtoMember(1)]
        private static readonly Regex Regex = new Regex(@"^\+380\d{3}\d{2}\d{2}\d{2}$");

        [DataMember]
        [ProtoMember(2)]
        public Dictionary<TelNum, AbonentName> PhoneBook;

        [DataMember]
        [ProtoMember(3)]
        private string _number;

        public TelNum Number
        {
            get => _number;
            set
            {
                if (Regex.IsMatch(value))
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException("This phone number is incorrect");
                }
            }
        }

        [DataMember]
        [ProtoMember(4)]
        public AbonentName AbonentName { get; set; }

        public MobileAccount() { }

        public MobileAccount(TelNum number, AbonentName name)
        {
            PhoneBook = new Dictionary<TelNum, AbonentName>();
            Number = number;
            AbonentName = name;
        }

        public void ConnectToAnOperator(MobileOperator mobileOperator)
        {
            mobileOperator.CallExecutor += Call;
            mobileOperator.MessageExecutor += Message;
        }

        public void DisconnectFromOperator(MobileOperator mobileOperator)
        {
            mobileOperator.CallExecutor -= Call;
            mobileOperator.MessageExecutor -= Message;
        }

        public void Message(object sender, MessageData data)
        {
            if (data.ReceiverNum == Number)
            {
                WriteLine($"Abonent {AbonentName} ({Number}) got a message: \"{data.Text}\"");
                if (PhoneBook != null && PhoneBook.ContainsKey(data.SenderNum))
                {
                    WriteLine($"The message was sent by the abonent {PhoneBook[data.SenderNum]} ({data.SenderNum})");
                }
                WriteLine();
            }
        }

        public void Call(object sender, CallData data)
        {
            if (data.ReceiverNum == Number)
            {
                WriteLine($"Abonent {AbonentName} ({Number}) got a call");
                if (PhoneBook != null && PhoneBook.ContainsKey(data.SenderNum))
                {
                    WriteLine($"The call was made by the abonent {PhoneBook[data.SenderNum]} ({data.SenderNum})");
                }
                WriteLine();
            }
        }
    }
}
