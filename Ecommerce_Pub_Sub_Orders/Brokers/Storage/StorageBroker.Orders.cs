using Ecommerce_Pub_Sub_Orders.Models.DomainModels;

namespace Ecommerce_Pub_Sub_Orders.Brokers.Storage
{
    public partial class StorageBroker
    {
        private readonly List<Order> _orders=new();

        public List<Order> Orders =>
            _orders;

        public void Add(Order order)
        {
            _orders.Add(order);
        }
        public List<Order> GetOrders()
        {
            return _orders;
        }
    }
}
