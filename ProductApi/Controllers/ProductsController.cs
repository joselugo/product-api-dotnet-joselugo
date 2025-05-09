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

        // <summary>
        /// Obtiene la lista de productos disponibles.
        /// </summary>
        /// <returns>Lista de productos.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _service.GetProductsAsync();
            return Ok(products);
        }

        /// <summary>
        /// Obtiene un producto específico por su ID.
        /// </summary>
        /// <param name="id">Identificador del producto.</param>
        /// <returns>El producto solicitado o un error 404 si no se encuentra.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null)
                return NotFound(new { message = "Producto no encontrado" });

            return Ok(product);
        }

        /// <summary>
        /// Crea un nuevo producto en la base de datos.
        /// </summary>
        /// <param name="dto">Datos del producto a crear.</param>
        /// <returns>El producto creado.</returns>
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductDto dto)
        {
            var product = await _service.CreateProductAsync(dto);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="id">Identificador del producto a actualizar.</param>
        /// <param name="dto">Nuevos datos del producto.</param>
        /// <returns>Código 204 si se actualiza correctamente, o 404 si no se encuentra.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto dto)
        {
            var result = await _service.UpdateProductAsync(id, dto);
            if (!result)
                return NotFound(new { message = "Producto no encontrado" });

            return NoContent();
        }

        /// <summary>
        /// Elimina un producto por su ID.
        /// </summary>
        /// <param name="id">Identificador del producto a eliminar.</param>
        /// <returns>Código 204 si se elimina correctamente, o 404 si no se encuentra.</returns>
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
