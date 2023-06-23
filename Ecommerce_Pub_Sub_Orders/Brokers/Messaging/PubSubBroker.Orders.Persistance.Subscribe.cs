using Azure.Messaging.ServiceBus;

namespace Ecommerce_Pub_Sub_Orders.Brokers.Messaging
{
    public partial class PubSubBroker
    {
        private string OrderPersistanceSubscriptionName { get;} = "order-persistance-subscription";
      

        public ServiceBusProcessor OrderPersistanceProcessor()
        {
            return Processor(OrdersTopicName, OrderPersistanceSubscriptionName);
        }
    }
}
