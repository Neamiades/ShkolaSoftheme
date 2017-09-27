using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleMobile
{
    class MobileOperator : ITelephony
    {
        public event EventHandler<CallData>    CallExecutor;
        public event EventHandler<MessageData> MessageExecutor;

        public           List <MobileAccount> Accounts;
        private readonly List<CallData>       _callHistory;
        private readonly List<MessageData>    _messageHistory;

        public MobileOperator()
        {
            _callHistory = new List<CallData>();
            _messageHistory = new List<MessageData>();
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
                ); ;

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

        private void OnCallExecutor(CallData data) => CallExecutor?.Invoke(this, data);

        private void OnMessageExecutor(MessageData data) => MessageExecutor?.Invoke(this, data);
    }
}