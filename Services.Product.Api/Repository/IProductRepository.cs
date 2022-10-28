using Services.Product.Api.Models.Dto;

namespace Services.Product.Api.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int productId);
    }
}
