using System;

namespace ConsoleMobile
{
    public interface ITelephony
    {
        event EventHandler<CallData>    CallExecutor;
        event EventHandler<MessageData> MessageExecutor;

        void MakeCall(DateTime time, float price,
                      string senderNum, string receiverNum, bool byApp);

        void SendMessage(DateTime time, float price, string text,
                         string senderNum, string receiverNum, bool byApp);
    }
}
