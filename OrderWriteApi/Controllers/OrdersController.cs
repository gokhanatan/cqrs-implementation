using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderWriteApi.Models;
using OrderWriteApi.Services.Abstract;

namespace OrderWriteApi.Controllers
{
    [Route("api/order")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest createOrderRequest)
        {
            await _orderService.CreateOrder(createOrderRequest);

            return Ok();
        }
    }
}