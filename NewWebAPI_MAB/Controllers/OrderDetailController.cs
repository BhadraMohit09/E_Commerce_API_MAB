using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewWebAPI_MAB.Repositories;
using NewWebAPI_MAB.Models;
using System.Collections.Generic;

namespace NewWebAPI_MAB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailRepository _orderDetailRepository;

        public OrderDetailController(OrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        #region GetAll Order Details
        [HttpGet]
        public IActionResult GetAll()
        {
            var orderDetails = _orderDetailRepository.SelectAll();
            return Ok(orderDetails);
        }
        #endregion
    }
}
