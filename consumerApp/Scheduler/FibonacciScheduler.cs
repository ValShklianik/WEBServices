using System;
using System.Text;
using DAL;

namespace Scheduler
{
    public class FibonacciSheduler : IScheduler<long>
    {
        private ICalculationRepository repository = new CalculationRepository();
        public long SendMessage(long value)
        {
            var optionId = repository.AddOption(value);
            var queue = new RabbitMessageQueue();
            queue.SendMessage(optionId.ToString());
            return optionId;
        }
    }
}   
