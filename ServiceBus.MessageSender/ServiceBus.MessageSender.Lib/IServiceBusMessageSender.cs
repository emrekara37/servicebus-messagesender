using System.Threading.Tasks;

namespace ServiceBus.MessageSender.Lib
{
    public interface IServiceBusMessageSender
    {
        Task SendAsync(object input);
    }
}