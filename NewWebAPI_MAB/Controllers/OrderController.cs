using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewWebAPI_MAB.Repositories;

namespace NewWebAPI_MAB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        #region GetAll Orders
        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderRepository.SelectAll();
            return Ok(orders);
        }
        #endregion
    }
}
