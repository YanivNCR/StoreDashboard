using System.Threading.Tasks;
using System.Threading.Channels;
using System.Threading;
using System;
using WebApiWithBackgroundWorker.Common.Messaging;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using StoreDashboard.Model;

namespace WebApiWithBackgroundWorker.Subscriber.Messaging
{
    public class Consumer : IConsumer
    {
        private readonly ChannelReader<MessageWrapper> _reader;
        private readonly ILogger<Consumer> _logger;

        private readonly IMessagesRepository _messagesRepository;
        private readonly int _instanceId;
        private static readonly Random Random = new Random();

        public Consumer(ChannelReader<MessageWrapper> reader, ILogger<Consumer> logger, int instanceId, IMessagesRepository messagesRepository)
        {
            _reader = reader;
            _instanceId = instanceId;
            _logger = logger;
            _messagesRepository = messagesRepository;
        }

        public async Task BeginConsumeAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Consumer {_instanceId} > starting");

            try
            {
                await foreach (var message in _reader.ReadAllAsync(cancellationToken))
                {
                    _logger.LogInformation($"CONSUMER ({_instanceId})> Received message {message} : {message}");
                    await Task.Delay(500, cancellationToken);
                    _messagesRepository.Add(message);

                }
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogWarning($"Consumer {_instanceId} > forced stop");
            }

            _logger.LogInformation($"Consumer {_instanceId} > shutting down");
        }

    }
}
