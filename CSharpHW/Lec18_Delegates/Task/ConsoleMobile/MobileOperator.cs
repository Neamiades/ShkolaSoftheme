using System;
using System.Collections.Generic;

namespace ConsoleMobile
{
    class MobileOperator : ITelephony
    {
        public event EventHandler<CallData>    CallExecutor;
        public event EventHandler<MessageData> MessageExecutor;

        public           List <MobileAccount> Accounts;

        public void MakeCall(DateTime time, float price,
                             string senderNum, string receiverNum, bool byApp)
        {
            var data = new CallData(time, price, senderNum, receiverNum, byApp);
            OnCallExecutor(data);
        }

        public void SendMessage(DateTime time, float price, string text,
                                string senderNum, string receiverNum, bool byApp)
        {
            var data = new MessageData(time, price, text, senderNum, receiverNum, byApp);
            OnMessageExecutor(data);
        }

        private void OnCallExecutor(CallData data) => CallExecutor?.Invoke(this, data);

        private void OnMessageExecutor(MessageData data) => MessageExecutor?.Invoke(this, data);
    }
}