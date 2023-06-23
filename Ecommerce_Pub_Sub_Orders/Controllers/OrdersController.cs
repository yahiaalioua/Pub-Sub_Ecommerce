using Ecommerce_Pub_Sub_Orders.Models.DomainModels;
using Ecommerce_Pub_Sub_Orders.Services.FoundationServices.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Pub_Sub_Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersFoundationService _ordersFoundationService;

        public OrdersController(IOrdersFoundationService ordersFoundationService)
        {
            _ordersFoundationService = ordersFoundationService;
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder(Order order)
        {
            await _ordersFoundationService.PlaceNewOrder(order);
            return Ok();
        }
        [HttpGet]
        [Route("Orders")]
        public IActionResult GetOrders()
        {
            return Ok(_ordersFoundationService.GetOrders());
        }
        [HttpGet]
        [Route("OrderBills")]
        public IActionResult GetOrderBills()
        {
            return Ok(_ordersFoundationService.GetOrderBills());
        }
        [HttpGet]
        [Route("DeliveryNotes")]
        public IActionResult GetDeliveryNotes()
        {
            return Ok(_ordersFoundationService.GetDeliveryNotes());
        }
    }
}
