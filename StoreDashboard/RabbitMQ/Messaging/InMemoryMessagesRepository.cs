using Newtonsoft.Json.Linq;
using StoreDashboard.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiWithBackgroundWorker.Common.Messaging;

namespace WebApiWithBackgroundWorker.Subscriber.Messaging
{
    public class InMemoryMessagesRepository : IMessagesRepository
    {
        private readonly Queue<MessageWrapper> _messages;

        public InMemoryMessagesRepository()
        {
            _messages = new Queue<MessageWrapper>();
        }

        public void Add(MessageWrapper message) 
        {
            _messages.Enqueue(message ?? throw new ArgumentNullException(nameof(message)));
        }

        public IReadOnlyCollection<MessageWrapper> GetMessages()
        {
            return _messages.ToArray();
        }
    }
}