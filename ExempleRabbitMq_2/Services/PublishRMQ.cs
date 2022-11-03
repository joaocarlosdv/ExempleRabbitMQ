using ExempleRabbitMq_2.Models;
using ExempleRabbitMq_2.Services.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace ExempleRabbitMq_2.Services
{
    public class PublishRMQ : IPublishRMQ
    {
        public bool Publish(ModelExemple obj)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ConfirmSelect();

                channel.QueueDeclare(queue: "mylist",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var json = JsonConvert.SerializeObject(obj);
                var body = Encoding.UTF8.GetBytes(json);

                try
                {
                    channel.BasicPublish(exchange: "",
                                     routingKey: "mylist",
                                     basicProperties: null,
                                     body: body);

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
