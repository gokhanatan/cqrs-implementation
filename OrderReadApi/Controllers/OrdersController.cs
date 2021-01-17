using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderReadApi.Services.Abstract;

namespace OrderReadApi.Controllers
{
    [Route("api/orderreader")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getbycode")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var listingOrder = await _orderService.GetByCode(code);

            if (listingOrder == null)
                return NotFound();

            return Ok(listingOrder);
        }
    }
}