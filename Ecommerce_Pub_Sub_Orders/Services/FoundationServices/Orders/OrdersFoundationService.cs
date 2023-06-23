using Azure.Messaging.ServiceBus;
using Ecommerce_Pub_Sub_Orders.Brokers.Messaging;
using Ecommerce_Pub_Sub_Orders.Brokers.Storage;
using Ecommerce_Pub_Sub_Orders.Models.DomainModels;
using Newtonsoft.Json;

namespace Ecommerce_Pub_Sub_Orders.Services.FoundationServices.Orders
{
    public class OrdersFoundationService : IOrdersFoundationService
    {
        private IPubSubBroker _pubSubBroker;
        private readonly StorageBroker _storageBroker;

        public OrdersFoundationService(IPubSubBroker pubSubBroker, StorageBroker storageBroker)
        {
            _pubSubBroker = pubSubBroker;
            _storageBroker = storageBroker;
        }

        public async Task PlaceNewOrder(Order order)
        {
            ServiceBusMessage sbMessage = new ServiceBusMessage(JsonConvert.SerializeObject(order))
            {
                MessageId = order.OrderId.ToString(),
                Subject = "Important",
            };
            sbMessage.ApplicationProperties["UserId"] = order.UserId;
            await _pubSubBroker.Publish(sbMessage);
        }

        public List<Order> GetOrders()
        {
            return _storageBroker.GetOrders();
        }

        public List<OrderBill> GetOrderBills()
        {
            return _storageBroker.GetOrderBills();
        }

        public List<DeliveryNote> GetDeliveryNotes()
        {
            return _storageBroker.GetDeliveryNotes();
        }
    }
}
