using Newtonsoft.Json.Linq;
using StoreDashboard.Model;
using System;
using WebApiWithBackgroundWorker.Common.Messaging;

namespace WebApiWithBackgroundWorker.Subscriber.Messaging
{
    public class RabbitSubscriberEventArgs : EventArgs{
        public RabbitSubscriberEventArgs(MessageWrapper message){
            this.Message = message;
        }

        public MessageWrapper Message {get;}
    }
}
