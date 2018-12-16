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
            HostName = "192.168.0.105",
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
                channel.ExchangeDeclare(exchange: exchangeName,
                                     durable: false,
                                     type: ExchangeType.Direct,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: exchangeName,
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);
            }
        }

        public void StartConsuming()
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
                channel.QueueBind(queueName, exchangeName, "");
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (ch, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);

                    int dots = message.Split('.').Length - 1;
                    
                    Console.WriteLine(" [x] Done");

                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };
                String consumerTag = channel.BasicConsume(queueName, false, consumer);
            }
        }
    }
}
