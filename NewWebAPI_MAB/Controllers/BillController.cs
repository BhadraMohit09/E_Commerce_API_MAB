using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewWebAPI_MAB.Repositories;
using System.Collections.Generic;

namespace NewWebAPI_MAB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly BillRepository _billRepository;

        public BillController(BillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        #region GetAll Bills
        [HttpGet]
        public IActionResult GetAllBills()
        {
            var bills = _billRepository.SelectAll();
            return Ok(bills);
        }
        #endregion
    }
}
