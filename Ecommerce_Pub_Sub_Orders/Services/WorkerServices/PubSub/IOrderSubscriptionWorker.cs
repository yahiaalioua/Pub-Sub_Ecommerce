namespace Ecommerce_Pub_Sub_Orders.Services.WorkerServices.PubSub
{
    public interface IOrderSubscriptionWorker
    {
        Task ProcessOrderSubscriptionAsync();
    }
}