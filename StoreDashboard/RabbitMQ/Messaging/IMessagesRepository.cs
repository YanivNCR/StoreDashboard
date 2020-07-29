using Newtonsoft.Json.Linq;
using StoreDashboard.Model;
using System.Collections.Generic;
using WebApiWithBackgroundWorker.Common.Messaging;

namespace WebApiWithBackgroundWorker.Subscriber.Messaging
{
    public interface IMessagesRepository
    {
        void Add(MessageWrapper message);
        IReadOnlyCollection<MessageWrapper> GetMessages();
    }
}