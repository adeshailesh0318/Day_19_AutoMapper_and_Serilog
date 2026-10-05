using Day19_AutoMapper_Serilog.DTOs;

namespace Day19_AutoMapper_Serilog.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();

        Task<ProductDto?> GetProductByIdAsync(int id);

        Task<ProductDto> CreateProductAsync(ProductDto productDto);

        Task<bool> DeleteProductAsync(int id);
    }
}