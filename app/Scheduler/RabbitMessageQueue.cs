using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Scheduler
{
    public class RabbitMessageQueue : IMessageQueue
    {
        private ConnectionFactory factory = new ConnectionFactory()
        {
            HostName = "rabbitmq",
            UserName = "lab",
            Password = "lab",
            VirtualHost = "lab_3_4"
        };
        private string exchangeName = "fibonacci";
        private string queueName = "fibonacci";
        public void SendMessage(string message)
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {   
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: exchangeName,
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);
            }
        }

        public void StartConsuming(ConsumerFunction consumerFunction)
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: exchangeName, durable: false, type: ExchangeType.Direct, autoDelete: false, arguments: null);

                channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
                channel.QueueBind(queueName, exchangeName, "");
                
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    consumerFunction(ea.Body);
                };
                channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
                while(true) {}
            }
        }
    }
}
