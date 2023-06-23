using Azure.Messaging.ServiceBus;

namespace Ecommerce_Pub_Sub_Orders.Brokers.Messaging
{
    public partial class PubSubBroker
    {
        private string OrderBillingSubscriptionName { get; } = "order-billing-subscription";


        public ServiceBusProcessor OrderBillingProcessor()
        {
            return Processor(OrdersTopicName, OrderBillingSubscriptionName);
        }
    }
}
