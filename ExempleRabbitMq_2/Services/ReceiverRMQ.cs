using ExempleRabbitMq_2.Models;
using ExempleRabbitMq_2.Services.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Text;

namespace ExempleRabbitMq_2.Services
{
    public class ReceiverRMQ : IReceiverRMQ
    {
        public ModelExemple Consumer()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "mylist",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                
                    var data = channel.BasicGet("mylist", true);
                    if (data != null)
                    {
                        var json = Encoding.UTF8.GetString(data.Body.ToArray());

                        return JsonConvert.DeserializeObject<ModelExemple>(json);
                    }
                    else
                    {
                        return null;
                    }                
            }
        }        
    }
}
