using Client.Web.Models;

namespace Client.Web.Services.IServices
{
    public class ProductService : BaseService, IProductService
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public ProductService(IHttpClientFactory httpClientFactory):base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType= SD.ApiType.POST,
                Data = productDto,
                URL=SD.ProductApiBase + "/api/products",
                AccessToken=""

            });
        }

        public async Task<T> DeleteProductAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.DELETE,
               URL = SD.ProductApiBase + "/api/products/"+ productId,
                AccessToken = ""

            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                URL = SD.ProductApiBase + "/api/products",
                AccessToken = ""

            });
        }

        public async Task<T> GetProductByIdAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                URL = SD.ProductApiBase + "/api/products/"+productId,
                AccessToken = ""

            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest
            {
                ApiType = SD.ApiType.PUT,
                Data = productDto,
                URL = SD.ProductApiBase + "/api/products",
                AccessToken = ""

            });
        }
    }
}
