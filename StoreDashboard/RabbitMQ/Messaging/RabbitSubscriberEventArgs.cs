using Newtonsoft.Json.Linq;
using System;
using WebApiWithBackgroundWorker.Common.Messaging;

namespace WebApiWithBackgroundWorker.Subscriber.Messaging
{
    public class RabbitSubscriberEventArgs : EventArgs{
        public RabbitSubscriberEventArgs(JObject message){
            this.Message = message;
        }

        public JObject Message {get;}
    }
}
