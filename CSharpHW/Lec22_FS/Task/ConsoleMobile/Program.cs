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
            using (var mobileOperator = new MobileOperator())
            {
                if (mobileOperator.ContainAccounts)
                {
                    ConnectAccsToOperator(mobileOperator, mobileOperator.Accounts);

                    MakeCalls(mobileOperator, mobileOperator.Accounts);

                    SendMessages(mobileOperator, mobileOperator.Accounts);

                    var (topCalledAccs, topActiveAccs) = mobileOperator.GetTopFives();

                    PrintTopList(topCalledAccs, topActiveAccs);
                }
            }
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

        private static void ConnectAccsToOperator(MobileOperator mobileOperator, List<MobileAccount> mobAccaunts)
        {
            foreach (var acc in mobAccaunts)
            {
                acc.ConnectToAnOperator(mobileOperator);
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