using Ecommerce_Pub_Sub_Orders.Brokers.Messaging;
using Ecommerce_Pub_Sub_Orders.Brokers.Storage;
using Ecommerce_Pub_Sub_Orders.Services.FoundationServices.Orders;
using Ecommerce_Pub_Sub_Orders.Services.WorkerServices.PubSub;

namespace Ecommerce_Pub_Sub_Orders.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddControllers();            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<IPubSubBroker, PubSubBroker>();
            services.AddTransient<IOrdersFoundationService, OrdersFoundationService>();
            services.AddSingleton<StorageBroker>();
            services.AddTransient<IOrderSubscriptionWorker, OrderSubscriptionWorker>();
            services.AddTransient<IOrderBillingSubscriptionWorker, OrderBillingSubscriptionWorker>();
            services.AddTransient<IOrderDeliverySubscriptionWorker, OrderDeliverySubscriptionWorker>();
            return services;
        }
    }
}
