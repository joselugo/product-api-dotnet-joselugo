using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.DTOs;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _service.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null)
                return NotFound(new { message = "Producto no encontrado" });

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductDto dto)
        {
            var product = await _service.CreateProductAsync(dto);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto dto)
        {
            var result = await _service.UpdateProductAsync(id, dto);
            if (!result)
                return NotFound(new { message = "Producto no encontrado" });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _service.DeleteProductAsync(id);
            if (!result)
                return NotFound(new { message = "Producto no encontrado" });

            return NoContent();
        }

    }
}
