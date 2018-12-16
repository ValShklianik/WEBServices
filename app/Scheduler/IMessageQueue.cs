using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler
{
    interface IMessageQueue
    {
        void SendMessage(string message);
        void StartConsuming();

    }
}
