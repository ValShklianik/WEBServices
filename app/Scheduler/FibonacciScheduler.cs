using System;

namespace Scheduler
{
    public class FibonacciSheduler : IScheduler<long>
    {
        public void SendMessage(long value)
        {
            Console.WriteLine(value);
        }
    }
}
