using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using WebApiWithBackgroundWorker.Common.Messaging;

namespace WebApiWithBackgroundWorker.Subscriber.Messaging
{
    public interface IMessagesRepository
    {
        void Add(JObject message);
        IReadOnlyCollection<JObject> GetMessages();
    }
}