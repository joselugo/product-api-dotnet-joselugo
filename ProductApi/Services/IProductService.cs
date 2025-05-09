using ProductApi.DTOs;
using ProductApi.Models;

namespace ProductApi.Services
{
    public interface IProductService
    {       
            Task<IEnumerable<Product>> GetProductsAsync();
            Task<Product?> GetProductByIdAsync(int id);
            Task<Product> CreateProductAsync(ProductDto dto);
            Task<bool> UpdateProductAsync(int id, ProductDto dto);
            Task<bool> DeleteProductAsync(int id);

    }
}
