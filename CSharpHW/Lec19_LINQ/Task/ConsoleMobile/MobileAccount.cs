using System;
using static System.Console;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using TelNum = System.String;
using AbonentName = System.String;

namespace ConsoleMobile
{
    class MobileAccount
    {
        private readonly Regex _regex;
        public Dictionary<TelNum, AbonentName> PhoneBook;
        private string _number;

        public TelNum Number
        {
            get => _number;
            set
            {
                if (_regex.IsMatch(value))
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException("This phone number is incorrect");
                }
            }
        }

        public AbonentName AbonentName { get; set; }

        public MobileAccount(TelNum number, AbonentName name)
        {
            PhoneBook = new Dictionary<TelNum, AbonentName>();
            _regex = new Regex(@"^\+380\d{3}\d{2}\d{2}\d{2}$");
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
                if (PhoneBook.ContainsKey(data.SenderNum))
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
                if (PhoneBook.ContainsKey(data.SenderNum))
                {
                    WriteLine($"The call was made by the abonent {PhoneBook[data.SenderNum]} ({data.SenderNum})");
                }
                WriteLine();
            }
        }
    }
}
