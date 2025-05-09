using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.DTOs;
using ProductApi.Models;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {

        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProductAsync(ProductDto dto)
        {
            var product = new Product
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Stock = dto.Stock,
                Activo = dto.Activo
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> UpdateProductAsync(int id, ProductDto dto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            product.Nombre = dto.Nombre;
            product.Precio = dto.Precio;
            product.Stock = dto.Stock;
            product.Activo = dto.Activo;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
