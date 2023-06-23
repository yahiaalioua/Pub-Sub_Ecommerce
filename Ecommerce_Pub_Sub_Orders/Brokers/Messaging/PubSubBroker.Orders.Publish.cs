using Azure.Messaging.ServiceBus;

namespace Ecommerce_Pub_Sub_Orders.Brokers.Messaging
{
    public partial class PubSubBroker:IPubSubBroker
    {
        public ServiceBusClient OrdersTopic { get; set; } = null!;
        public string OrdersTopicName { get;} = "new-order";

        public async Task Publish(ServiceBusMessage message)
        {
            ServiceBusSender sender = Sender(OrdersTopicName);
            await sender.SendMessageAsync(message);
        }


    }
}
