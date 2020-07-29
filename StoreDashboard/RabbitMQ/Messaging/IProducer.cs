using System.Threading.Tasks;
using WebApiWithBackgroundWorker.Common.Messaging;
using System.Threading;
using Newtonsoft.Json.Linq;
using StoreDashboard.Model;

namespace WebApiWithBackgroundWorker.Subscriber.Messaging
{
    public interface IProducer
    {
        Task PublishAsync(MessageWrapper message, CancellationToken cancellationToken = default);
    }
}
