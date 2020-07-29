using System.Threading.Tasks;
using WebApiWithBackgroundWorker.Common.Messaging;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace WebApiWithBackgroundWorker.Subscriber.Messaging
{
    public interface IProducer
    {
        Task PublishAsync(JObject message, CancellationToken cancellationToken = default);
    }
}
