using ExempleRabbitMq_2.Services;
using ExempleRabbitMq_2.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ExempleRabbitMq_2.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection ApiConfiServices(this IServiceCollection services)
        {
            services.AddScoped<IPublishRMQ, PublishRMQ>();
            services.AddScoped<IReceiverRMQ, ReceiverRMQ>();

            return services;
        }
    }
}
