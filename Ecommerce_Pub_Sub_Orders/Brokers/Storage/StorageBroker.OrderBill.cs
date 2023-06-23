using Ecommerce_Pub_Sub_Orders.Models.DomainModels;

namespace Ecommerce_Pub_Sub_Orders.Brokers.Storage
{
    public partial class StorageBroker
    {
        private readonly List<OrderBill> _orderBills=new();

        public List<OrderBill> OrderBills =>
            _orderBills;

        public void AddBill(OrderBill bill)
        {
            _orderBills.Add(bill);
        }
        public List<OrderBill> GetOrderBills()
        {
            return _orderBills;
        }
    }
}
