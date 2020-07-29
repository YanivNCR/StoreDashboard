using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using WebApiWithBackgroundWorker.Common.Messaging;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;
using BlazorChatSample.Server.Hubs;
using System.Timers;
using BlazorChatSample.Shared;

namespace WebApiWithBackgroundWorker.Subscriber.Messaging
{
    public class RabbitSubscriber : ISubscriber, IDisposable
    {
        private readonly IBusConnection _connection;
        private readonly IHubContext<ChatHub> _hubContext;
        private IModel _channel;
        private QueueDeclareOk _queue;
        private static System.Timers.Timer _aTimer;

        private const string ExchangeName = "DataEventPublisher";

        public RabbitSubscriber(IBusConnection connection, IHubContext<ChatHub> hubContext)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            this._hubContext = hubContext;
        }

        private void InitChannel()
        {
            _channel?.Dispose();
            
            _channel = _connection.CreateChannel();

            _channel.ExchangeDeclare(exchange: ExchangeName, type: ExchangeType.Fanout, true, false, null);
            
            // since we're using a Fanout exchange, we don't specify the name of the queue
            // but we let Rabbit generate one for us. This also means that we need to store the
            // queue name to be able to consume messages from it
            _queue = _channel.QueueDeclare(queue: "DataEventPublisherQueue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            _channel.QueueBind(_queue.QueueName, ExchangeName, string.Empty, null);

            _channel.CallbackException += (sender, ea) =>
            {
                InitChannel();
                InitSubscription();
            };
        }

        private void InitSubscription()
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            var x = 1;
            consumer.Received += OnMessageReceivedAsync;
            
            _channel.BasicConsume(queue: _queue.QueueName, autoAck: false, consumer: consumer);
        }

        private async Task OnMessageReceivedAsync(object sender, BasicDeliverEventArgs eventArgs)
        {
            try
            {
                var body = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
                var message = JsonSerializer.Deserialize<Message>(body);
                await this.OnMessage(this, new RabbitSubscriberEventArgs(message));
            }
            catch (Exception e)
            {

                throw;
            }
         
        }

        public event AsyncEventHandler<RabbitSubscriberEventArgs> OnMessage;

        public void Start()
        {
            InitChannel();
            InitSubscription();
            InitTimer();
        }

        private void InitTimer()
        {
            // Create a timer with a two second interval.
            _aTimer = new System.Timers.Timer(10000);
            // Hook up the Elapsed event for the timer. 
            _aTimer.Elapsed += OnTimedEvent;
            _aTimer.AutoReset = true;
            _aTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            _hubContext.Clients.All.SendAsync(Messages.RECEIVE, "yeh?", "yesh?");
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }
    }
}
