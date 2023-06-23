namespace Ecommerce_Pub_Sub_Orders.Models.DomainModels
{
    public class DeliveryNote
    {
        public Guid DeliveryNoteId { get; } = Guid.NewGuid();
        public string Name { get; set; } = null!;
        public string Address { get; set; }= null!;
        public string City { get; set; }=null!;
        public string PostalCode { get; set; }=null!;
        public string Country { get; set; }=null!;

    }
}
