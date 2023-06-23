using Azure.Messaging.ServiceBus;

namespace Ecommerce_Pub_Sub_Orders.Brokers.Messaging
{
    public partial class PubSubBroker:IPubSubBroker
    {
        private readonly IConfiguration _configuration;

        public PubSubBroker(IConfiguration configuration)
        {
            _configuration = configuration;
            InitializePubSubClients(); 
        }

        private void InitializePubSubClients() =>
            this.OrdersTopic = GetServiceBusClient();

        private ServiceBusClientOptions ClientOptions()
        {
            return new ServiceBusClientOptions
            {
                RetryOptions = new ServiceBusRetryOptions() { MaxRetries = 3,Delay=TimeSpan.FromSeconds(10)},
                TransportType=ServiceBusTransportType.AmqpWebSockets               
                
            };
        }
        private ServiceBusProcessorOptions ProcessorOptions()
        {
            return new ServiceBusProcessorOptions
            {
                AutoCompleteMessages = false,
                //vi setter den til 3 eller 4 dersom vi skal ha 3 services som skal listen til denne topic
                MaxConcurrentCalls = 3,
                ReceiveMode=ServiceBusReceiveMode.PeekLock
            };
        }

        private ServiceBusClient GetServiceBusClient()
        {
            string connStr = _configuration.GetConnectionString("ServiceBusConnStr")!;
            return new ServiceBusClient(connStr,ClientOptions());
        }
        private ServiceBusSender Sender(string topicName)
        {
            ServiceBusClient serviceBusClient = GetServiceBusClient();
            ServiceBusSender serviceBusSender = serviceBusClient.CreateSender(topicName);
            return serviceBusSender;
        }
        public ServiceBusProcessor Processor(string topicName,string subscriptionName)
        {
            ServiceBusClient serviceBusClient = GetServiceBusClient();
            ServiceBusProcessor serviceBusProcessor = serviceBusClient.CreateProcessor(topicName,subscriptionName,ProcessorOptions());
            return serviceBusProcessor;
        }
    }
}
