using System;
using System.Collections.Generic;
using static System.Console;

namespace ConsoleMobile
{
    class Program
    {
        private const int CallsCount    = 30;
        private const int MessagesCount = 50;
        private const int EntitiesCount = 10;

        private static readonly Random   Rnd    = new Random();
        private static readonly string[] MsgTxt = new string[EntitiesCount]{
            "Hello!",
            "Love you!",
            "Jugokku!",
            "Rasengan!",
            "I'll kill you!",
            "Here is Johny!!!",
            "I got a new JOB!",
            "I'm your God!",
            "Good night!",
            "I'm became a Dragon!"
        };

        static void Main()
        {
            var mobileOperator = new MobileOperator();

            mobileOperator.Accounts = GetAccaunts();

            ConnectAccsToOperator(mobileOperator, mobileOperator.Accounts);

            FillPhoneBooks(mobileOperator.Accounts);

            MakeCalls(mobileOperator, mobileOperator.Accounts);

            SendMessages(mobileOperator, mobileOperator.Accounts);

            var (topCalledAccs, topActiveAccs) = mobileOperator.GetTopFives();

            PrintTopList(topCalledAccs, topActiveAccs);
        }

        private static void PrintTopList(IEnumerable<TopAcc> topCalledAccs, IEnumerable<TopAcc> topActiveAccs)
        {
            WriteLine("5 most frequently called numbers:");
            foreach (var number in topCalledAccs)
            {
                WriteLine($"Abonent: {number.Name}, Number: {number.Number}, Count: {number.Count}");
            }
            WriteLine();

            WriteLine("5 most active abonents by SMS and calls (SMS message as 0.5 call):");
            foreach (var number in topActiveAccs)
            {
                WriteLine($"Abonent: {number.Name}, Number: {number.Number}, Total Score: {number.Count}");
            }
            WriteLine();
        }

        private static List<MobileAccount> GetAccaunts()
        {
            return new List<MobileAccount>
                {
                    new MobileAccount("+380934596888", "Serhii Yakhin"),
                    new MobileAccount("+380934596800", "Vitaliy Sloboda"),
                    new MobileAccount("+380934596801", "Ann Dubok"),
                    new MobileAccount("+380934596802", "Grisha Master"),
                    new MobileAccount("+380934596803", "John Cena"),
                    new MobileAccount("+380934596804", "Witch King of Angmar"),
                    new MobileAccount("+380934596805", "Solomon Gandi"),
                    new MobileAccount("+380934596806", "The Rock"),
                    new MobileAccount("+380934596807", "Lolita Gumbert"),
                    new MobileAccount("+380934596808", "Jacky Chan")
                };
        }

        private static void ConnectAccsToOperator(MobileOperator mobileOperator, List<MobileAccount> mobAccaunts)
        {
            foreach (var acc in mobAccaunts)
            {
                acc.ConnectToAnOperator(mobileOperator);
            }
        }

        private static void FillPhoneBooks(List<MobileAccount> mobAccaunts)
        {
            for (int i = 0; i < mobAccaunts.Count; i++)
            {
                for (int j = i + 1; j < mobAccaunts.Count; j++)
                {
                    mobAccaunts[i].PhoneBook.Add(mobAccaunts[j].Number, mobAccaunts[j].AbonentName);
                }
            }
        }

        private static void MakeCalls(MobileOperator mobileOperator, List<MobileAccount> mobAccaunts)
        {
            WriteLine("-------------------Start of Calling---------------------\n");
            for (int i = 0; i < CallsCount; i++)
            {
                mobileOperator.MakeCall(
                    DateTime.Now,
                    0.50f,
                    mobAccaunts[Rnd.Next(0, EntitiesCount)].Number,
                    mobAccaunts[Rnd.Next(0, EntitiesCount)].Number,
                    byApp: true);
            }
            WriteLine("-------------------End of Calling---------------------\n");
        }

        private static void SendMessages(MobileOperator mobileOperator, List<MobileAccount> mobAccaunts)
        {
            WriteLine("-------------------Start of Messaging---------------------\n");
            for (int i = 0; i < MessagesCount; i++)
            {
                mobileOperator.SendMessage(
                    DateTime.Now,
                    0.50f,
                    MsgTxt[Rnd.Next(0, EntitiesCount)],
                    mobAccaunts[Rnd.Next(0, EntitiesCount)].Number,
                    mobAccaunts[Rnd.Next(0, EntitiesCount)].Number,
                    byApp: true);
            }
            WriteLine("-------------------End of Messaging---------------------\n");
        }
    }
}