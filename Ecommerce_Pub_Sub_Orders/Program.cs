using Ecommerce_Pub_Sub_Orders.Brokers.Messaging;
using Ecommerce_Pub_Sub_Orders.Brokers.Storage;
using Ecommerce_Pub_Sub_Orders.DependencyInjection;
using Ecommerce_Pub_Sub_Orders.Services.FoundationServices.Orders;
using Ecommerce_Pub_Sub_Orders.Services.WorkerServices.PubSub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Services.GetService<IOrderSubscriptionWorker>()!.ProcessOrderSubscriptionAsync();
app.Services.GetService<IOrderBillingSubscriptionWorker>()!.ProcessOrderSubscriptionAsync();
app.Services.GetService<IOrderDeliverySubscriptionWorker>()!.ProcessOrderSubscriptionAsync();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
