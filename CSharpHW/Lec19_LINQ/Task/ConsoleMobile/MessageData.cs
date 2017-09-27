using System;

namespace ConsoleMobile
{
    public class MessageData : EventArgs
    {
        public DateTime Time        { get; }
        public float    Price       { get; }
        public string   Text        { get; }
        public bool     ByApp       { get; }
        public string   SenderNum   { get; }
        public string   ReceiverNum { get; }

        public MessageData(DateTime time, float price, string text,
                           string senderNum, string receiverNum, bool byApp)
        {
            Time = time;
            Price = price;
            ByApp = byApp;
            Text = text;
            SenderNum = senderNum;
            ReceiverNum = receiverNum;
        }
    }
}
