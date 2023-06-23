using Azure.Messaging.ServiceBus;
using Ecommerce_Pub_Sub_Orders.Brokers.Messaging;
using Ecommerce_Pub_Sub_Orders.Brokers.Storage;
using Ecommerce_Pub_Sub_Orders.Models.DomainModels;
using Newtonsoft.Json;

namespace Ecommerce_Pub_Sub_Orders.Services.WorkerServices.PubSub
{
    public class OrderBillingSubscriptionWorker : IOrderBillingSubscriptionWorker
    {
        private readonly ILogger<OrderBillingSubscriptionWorker> _logger;
        private readonly StorageBroker _storageBroker;
        private readonly IPubSubBroker _pubSubBroker;

        public OrderBillingSubscriptionWorker(StorageBroker storageBroker, IPubSubBroker pubSubBroker, ILogger<OrderBillingSubscriptionWorker> logger)
        {
            _storageBroker = storageBroker;
            _pubSubBroker = pubSubBroker;
            _logger = logger;
        }

        public async Task ProcessOrderSubscriptionAsync()
        {
            var processor = _pubSubBroker.OrderBillingProcessor();
            processor.ProcessMessageAsync += HandleMessageAsync;
            processor.ProcessErrorAsync += HandleErrorAsync;
            await processor.StartProcessingAsync();
        }
        private async Task HandleMessageAsync(ProcessMessageEventArgs messageEventArgs)
        {
            try
            {
                _logger.LogInformation($"Mapping message to an order bill and adding to database, Date Time:{DateTime.UtcNow}");
                Order order = JsonConvert.DeserializeObject<Order>(messageEventArgs.Message.Body.ToString())!;
                double totalPayable = 0;
                foreach (var item in order.Products)
                {
                    totalPayable += item.Price;
                }
                OrderBill orderBill = new OrderBill() { TotalPayable = totalPayable};

                _storageBroker.AddBill(orderBill);
                // etter at vi har behandlet vårt melding da kan vi gi beskjed til topic at melding
                // er behandlet og deretter skal slettes slik at ingen andre kan behandle det på nytt
                await messageEventArgs.CompleteMessageAsync(messageEventArgs.Message);
                _logger.LogInformation($"message processed succesfully, Date Time:{DateTime.UtcNow}");
            }
            catch (Exception)
            {
                _logger.LogWarning($"Message could not be processed, adding to dead letter, DateTime:{DateTime.UtcNow}");
                // hvis det er oppstått en feil og vi kan ikke behandle meldingen, da kan vi veldger å løse opp meldingen,
                //og la en annen forbrukerer prøve på nytt, eller vi kan flytter meldingen til dead letter queue,
                //eller vi kan defferre melding slik at den sitter ved side og kan bli behandlet på nytt
                await messageEventArgs.DeadLetterMessageAsync(messageEventArgs.Message);
            }
        }

        private Task HandleErrorAsync(ProcessErrorEventArgs errorEventArgs)
        {
            _logger.LogError($"An Error occurred,{errorEventArgs.Exception}, Date Time:{DateTime.UtcNow}");
            return Task.CompletedTask;
        }
    }
}
