namespace Ecommerce_Pub_Sub_Orders.Models.DomainModels
{
    public class OrderBill
    {
        public Guid BillId { get; } = Guid.NewGuid();
        public double TotalPayable { get; set; }

    }
}
