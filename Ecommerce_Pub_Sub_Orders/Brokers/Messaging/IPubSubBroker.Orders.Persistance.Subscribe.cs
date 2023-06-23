using Azure.Messaging.ServiceBus;

namespace Ecommerce_Pub_Sub_Orders.Brokers.Messaging
{
    public partial interface IPubSubBroker
    {
        ServiceBusProcessor OrderPersistanceProcessor();
    }
}
