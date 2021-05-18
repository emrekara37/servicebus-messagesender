using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace ServiceBus.MessageSender.Lib
{
    public class ServiceBusMessageSender : IServiceBusMessageSender
    {
        private readonly IConfiguration _configuration;

        public ServiceBusMessageSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task SendAsync(object input)
        {

            await using var client = new Azure.Messaging.ServiceBus.ServiceBusClient(_configuration[ServiceBusConfiguration.Connection]);

            string queueOrTopicName;

            if (ServiceBusConfiguration.QueueOrTopicName.StartsWith("%") && ServiceBusConfiguration.QueueOrTopicName.EndsWith("%"))
            {
                queueOrTopicName = _configuration[ServiceBusConfiguration.QueueOrTopicName.Replace("%", "")];
            }
            else
            {
                queueOrTopicName = ServiceBusConfiguration.QueueOrTopicName;
            }

            ServiceBusSender sender = client.CreateSender(queueOrTopicName);

            ServiceBusMessage message = new ServiceBusMessage(JsonSerializer.Serialize(input));
            await sender.SendMessageAsync(message);
        }
    }
}