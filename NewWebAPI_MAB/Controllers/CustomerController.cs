using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewWebAPI_MAB.Repositories;

namespace NewWebAPI_MAB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        #region GetAll Customers
        [HttpGet]
        public IActionResult Index()
        {
            var customer = _customerRepository.SelectAll();
            return Ok(customer);
        }
        #endregion
    }
}
