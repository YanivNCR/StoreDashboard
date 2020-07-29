using System.Threading.Tasks;
using WebApiWithBackgroundWorker.Common.Messaging;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace WebApiWithBackgroundWorker.Subscriber.Messaging
{
    public class Producer : IProducer
    {
        private readonly ChannelWriter<JObject> _writer;
        private readonly ILogger<Producer> _logger;

        public Producer(ChannelWriter<JObject> writer, ILogger<Producer> logger)
        {
            _writer = writer;
            _logger = logger;
        }

        public async Task PublishAsync(JObject message, CancellationToken cancellationToken = default)
        {
            await _writer.WriteAsync(message, cancellationToken);
            _logger.LogInformation($"Producer > published message {message} '{message}'");
        }
    }
}
