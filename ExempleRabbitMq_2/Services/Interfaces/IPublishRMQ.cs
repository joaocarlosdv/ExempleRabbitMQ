using ExempleRabbitMq_2.Models;

namespace ExempleRabbitMq_2.Services.Interfaces
{
    public interface IPublishRMQ
    {
        bool Publish(ModelExemple obj);
    }
}
