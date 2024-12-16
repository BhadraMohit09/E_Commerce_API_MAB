using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewWebAPI_MAB.Models;
using NewWebAPI_MAB.Repositories;

namespace NewWebAPI_MAB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #region GetAll Products
        [HttpGet]
        public IActionResult Index()
        {
            var products = _productRepository.SelectAll();
            return Ok(products);
        }
        #endregion

        #region GetByID Product
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productRepository.SelectByPK(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        #endregion

        #region Delete Product
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var isDeleted = _productRepository.Delete(id);

            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        #endregion

        #region InsertProduct
        [HttpPost]
        public IActionResult InsertProduct([FromBody] ProductModel product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            bool isInserted = _productRepository.Insert(product);

            if (isInserted)
                return Ok(new { Message = "Product inserted..." });
            return StatusCode(500, "An error occureed");
        }
        #endregion


        #region UpdateProduct
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductModel product)
        {
            if (product == null || id != product.ProductID)
            {
                return BadRequest();
            }

            var isUpdated = _productRepository.Update(product);

            if (!isUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }
        #endregion
    }
}
