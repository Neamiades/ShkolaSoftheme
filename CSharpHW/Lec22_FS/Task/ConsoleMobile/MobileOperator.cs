using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ConsoleMobile
{
    class MobileOperator : ITelephony, IDisposable
    {
        public event EventHandler<CallData>    CallExecutor;
        public event EventHandler<MessageData> MessageExecutor;

        public bool ContainAccounts { get; }

        public           List <MobileAccount> Accounts;
        private readonly List<CallData>       _callHistory;
        private readonly List<MessageData>    _messageHistory;

        public MobileOperator(StorageType storageType = StorageType.BinaryInZip)
        {
            _callHistory = new List<CallData>();
            _messageHistory = new List<MessageData>();
            try
            {
                if (storageType == StorageType.BinaryInZip)
                {
                    DecompresAndLoad();
                }
                else
                {
                    Deserialize();
                }
            }
            catch (FileNotFoundException ex)
            {
                LogErr(ex);
                Console.WriteLine("The mobile operator was unable to find files with accounts data");
            }
            catch (SerializationException ex)
            {
                LogErr(ex);
                Console.WriteLine("The mobile operator was unable to take data from files");
            }
            catch (Exception ex)
            {
                LogErr(ex);
                Console.WriteLine("Unexpected error in program work");
            }
            ContainAccounts = Accounts?.Count > 0;
            if (!ContainAccounts)
            {
                Console.WriteLine("The mobile operator doesn't contain any accounts at this moment, try later");
            }
        }

        public (IEnumerable<TopAcc>, IEnumerable<TopAcc>) GetTopFives()
        {
            var topNumbers = _callHistory
                .GroupBy(c => c.ReceiverNum)
                .OrderByDescending(g => g.Count()).Take(5)
                .Select(g => new TopAcc
                {
                    Number = g.Key,
                    Count = g.Count()
                })
                .Join(Accounts,
                topN => topN.Number,
                acc => acc.Number,
                (topN, acc) => new TopAcc
                {
                    Number = topN.Number,
                    Name = acc.AbonentName,
                    Count = topN.Count
                }
                );

            var topAbonents = _callHistory
                .GroupBy(c => c.SenderNum)
                .Select(g => new
                {
                    SenderNum = g.Key,
                    CallCount = g.Count()
                })
                .Join(_messageHistory
                        .GroupBy(m => m.SenderNum)
                        .Select(g => new
                        {
                            SenderNum = g.Key,
                            MessageScore = g.Count() / 2.0
                        }),
                    c => c.SenderNum,
                    m => m.SenderNum,
                    (c, m) => new TopAcc
                    {
                        Number = c.SenderNum,
                        Count = c.CallCount + m.MessageScore
                    }
                )
                .OrderByDescending(num => num.Count)
                .Take(5)
                .Join(Accounts,
                    topA => topA.Number,
                    acc => acc.Number,
                    (topA, acc) => new TopAcc
                    {
                        Number = topA.Number,
                        Name = acc.AbonentName,
                        Count = topA.Count
                    }
                );

            return (topNumbers, topAbonents);
        }

        public void MakeCall(DateTime time, float price,
                             string senderNum, string receiverNum, bool byApp)
        {
            var data = new CallData(time, price, senderNum, receiverNum, byApp);
            _callHistory.Add(data);
            OnCallExecutor(data);
        }

        public void SendMessage(DateTime time, float price, string text,
                                string senderNum, string receiverNum, bool byApp)
        {
            var data = new MessageData(time, price, text, senderNum, receiverNum, byApp);
            _messageHistory.Add(data);
            OnMessageExecutor(data);
        }

        private void CompressAndSave()
        {
            using (var ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, Accounts);
                using (var fs = new FileStream("Accounts.zip", FileMode.OpenOrCreate))
                {
                    using (ZipArchive archive = new ZipArchive(fs, ZipArchiveMode.Create, false))
                    {
                        var zipEntry = archive.CreateEntry("Accounts.bin");
                        using (var zipEntryStream = zipEntry.Open())
                        {
                            ms.Position = 0;
                            ms.CopyTo(zipEntryStream);
                        }
                    }
                }
            }
        }

        private void DecompresAndLoad()
        {
            using (ZipArchive archive = ZipFile.OpenRead("Accounts.zip"))
            {
                var zipEntry = archive.GetEntry("Accounts.bin");
                using (var zipEntryStream = zipEntry.Open())
                {
                    using (var ms = new MemoryStream())
                    {
                        zipEntryStream.CopyTo(ms);
                        ms.Position = 0;
                        Accounts = ProtoBuf.Serializer.Deserialize<List<MobileAccount>>(ms);
                    }
                }
            }
        }

        private static void LogErr(Exception ex)
        {
            using (var sw = new StreamWriter("ErrorsLog.txt", append: true))
            {
                sw.Write($"\n\n#{DateTime.Now} - {ex.Message}\n");
            }
        }

        private void Serialize()
        {
            using (FileStream fs = new FileStream("Accounts.json", FileMode.Create))
            {
                new DataContractJsonSerializer(typeof(List<MobileAccount>)).WriteObject(fs, Accounts);
            }
        }

        private void Deserialize()
        {
            using (FileStream fs = new FileStream("Accounts.json", FileMode.Open))
            {
                Accounts = (List<MobileAccount>)new DataContractJsonSerializer(typeof(List<MobileAccount>)).ReadObject(fs);
            }
        }

        private void OnCallExecutor(CallData data) => CallExecutor?.Invoke(this, data);

        private void OnMessageExecutor(MessageData data) => MessageExecutor?.Invoke(this, data);

        public void Dispose()
        {
            CompressAndSave();
            Serialize();
        }
    }
}