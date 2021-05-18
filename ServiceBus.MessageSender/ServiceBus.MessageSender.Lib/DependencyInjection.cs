using Microsoft.Extensions.DependencyInjection;

namespace ServiceBus.MessageSender.Lib
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceBusMessageSender(this IServiceCollection services)
        {
            services.AddTransient<IServiceBusMessageSender, ServiceBusMessageSender>();
            return services;
        }
    }
}