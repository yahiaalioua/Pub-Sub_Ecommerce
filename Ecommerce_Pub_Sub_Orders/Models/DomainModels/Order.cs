namespace Ecommerce_Pub_Sub_Orders.Models.DomainModels
{
    public class Order
    {
        public Guid OrderId { get;}=Guid.NewGuid();
        public int UserId { get; set; }
        public List<Product> Products { get; set; } = null!;
        public DeliveryNote DeliveryDetails { get; set; }

    }
}
