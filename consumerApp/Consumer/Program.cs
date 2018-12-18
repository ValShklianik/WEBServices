using System;
using Scheduler;
using System.Text;
using DAL;
using System.Collections.Generic;

namespace Consumer
{
    class Program
    {
        private static ICalculationRepository repository = new CalculationRepository();
        private static List<long> fibonacciNumbers(long len)
        {
            long first =  0, second = 1;
            List<long> res = new List<long>();
            res.Add(first);
            res.Add(second);
            len -= 2;
            while (len > 0)
            {
                len--;
                long temp = second;
                second += first;
                first = temp;
                res.Add(second);
            }
            return res;
        } 
        static void Main(string[] args)
        {
            
            Console.WriteLine("Consuming....");
            var messageQueue = new RabbitMessageQueue();
            messageQueue.StartConsuming((body) =>
                {
                    var pk = Int32.Parse(Encoding.UTF8.GetString(body));
                    var option = repository.GetOption(pk);
                    repository.SaveResult(pk, fibonacciNumbers(option.InputData));                  

                    Console.WriteLine(" [x] Received {0}", option.InputData);
                    Console.WriteLine(" [x] Done");
                });
        }
    }
}
