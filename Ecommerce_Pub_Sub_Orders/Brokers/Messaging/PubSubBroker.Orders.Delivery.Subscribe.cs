using Azure.Messaging.ServiceBus;

namespace Ecommerce_Pub_Sub_Orders.Brokers.Messaging
{
    public partial class PubSubBroker
    {
        private string OrderDeliverySubscriptionName { get; } = "order-delivery-subscription";


        public ServiceBusProcessor OrderDeliveryProcessor()
        {
            return Processor(OrdersTopicName, OrderDeliverySubscriptionName);
        }
    }
}
