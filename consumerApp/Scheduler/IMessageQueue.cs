using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler
{
    public delegate void ConsumerFunction(byte[] body);
    interface IMessageQueue
    {
        void SendMessage(string message);
        void StartConsuming(ConsumerFunction consumerFunction);

    }
}
