using Ecommerce_Pub_Sub_Orders.Models.DomainModels;

namespace Ecommerce_Pub_Sub_Orders.Brokers.Storage
{
    public partial class StorageBroker
    {
        private readonly List<DeliveryNote> _deliveryNotes = new();

        public List<DeliveryNote> DeliveryNotes =>
            _deliveryNotes;

        public void AddDeliveryNote(DeliveryNote bill)
        {
            _deliveryNotes.Add(bill);
        }
        public List<DeliveryNote> GetDeliveryNotes()
        {
            return _deliveryNotes;
        }
    }
}
