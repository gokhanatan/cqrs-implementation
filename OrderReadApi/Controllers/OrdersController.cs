using Microsoft.AspNetCore.Mvc;

namespace OrderReadApi.Controllers
{
    [Route("api/orderreader")]
    public class OrdersController : ControllerBase
    {
        public OrdersController()
        {
            
        }

        [HttpGet("getbycode")]
        public IActionResult GetByCode(string code)
        {
            return Ok();
        }
    }
}