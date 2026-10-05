using Day19_AutoMapper_Serilog.DTOs;
using Day19_AutoMapper_Serilog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day19_AutoMapper_Serilog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService,ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            _logger.LogInformation("Getting all products");

            var products = await _productService.GetAllProductsAsync();

            _logger.LogInformation(
                "Successfully retrieved {Count} products",
                products.Count);

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            _logger.LogInformation("Getting product with Id: {ProductId}",id);

            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                _logger.LogWarning(
                    "Product with Id {ProductId} was not found",
                    id);

                return NotFound(new
                {
                    message = "Product not found"
                });
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            _logger.LogInformation(
                "Creating new product: {ProductName}",
                productDto.Name);

            var product =
                await _productService.CreateProductAsync(productDto);

            _logger.LogInformation(
                "Product created successfully with Id: {ProductId}",
                product.Id);

            return CreatedAtAction(
                nameof(GetProductById),
                new { id = product.Id },
                product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            _logger.LogInformation(
                "Deleting product with Id: {ProductId}",
                id);

            var result =
                await _productService.DeleteProductAsync(id);

            if (!result)
            {
                _logger.LogWarning(
                    "Cannot delete product. Product with Id {ProductId} not found",
                    id);

                return NotFound(new
                {
                    message = "Product not found"
                });
            }

            _logger.LogInformation(
                "Product with Id {ProductId} deleted successfully",
                id);

            return Ok(new
            {
                message = "Product deleted successfully"
            });
        }
    }
}