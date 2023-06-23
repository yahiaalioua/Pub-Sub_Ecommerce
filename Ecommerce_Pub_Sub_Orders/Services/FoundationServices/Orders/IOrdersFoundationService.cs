using Ecommerce_Pub_Sub_Orders.Models.DomainModels;

namespace Ecommerce_Pub_Sub_Orders.Services.FoundationServices.Orders
{
    public interface IOrdersFoundationService
    {
        Task PlaceNewOrder(Order order);
        List<DeliveryNote> GetDeliveryNotes();
        List<OrderBill> GetOrderBills();
        List<Order> GetOrders();
    }
}