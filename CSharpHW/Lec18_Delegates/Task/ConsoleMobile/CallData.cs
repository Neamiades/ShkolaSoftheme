using System;

namespace ConsoleMobile
{
    public class CallData : EventArgs
    {
        public DateTime Time        { get; }
        public float    Price       { get; }
        public bool     ByApp       { get; }
        public string   SenderNum   { get; }
        public string   ReceiverNum { get; }

        public CallData(DateTime time, float price,
                        string senderNum, string receiverNum, bool byApp)
        {
            Time = time;
            Price = price;
            ByApp = byApp;
            SenderNum = senderNum;
            ReceiverNum = receiverNum;
        }
    }
}
