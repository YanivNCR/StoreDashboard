using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiWithBackgroundWorker.Common.Messaging;

namespace WebApiWithBackgroundWorker.Subscriber.Messaging
{
    public class InMemoryMessagesRepository : IMessagesRepository
    {
        private readonly Queue<JObject> _messages;

        public InMemoryMessagesRepository()
        {
            _messages = new Queue<JObject>();
        }

        public void Add(JObject message)
        {
            _messages.Enqueue(message ?? throw new ArgumentNullException(nameof(message)));
        }

        public IReadOnlyCollection<JObject> GetMessages()
        {
            return _messages.ToArray();
        }
    }
}