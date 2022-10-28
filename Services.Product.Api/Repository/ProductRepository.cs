using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.Product.Api.DBContext;
using Services.Product.Api.Models.Dto;

namespace Services.Product.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Services.Product.Api.Models.Product product=_mapper.Map<ProductDto, Services.Product.Api.Models.Product>(productDto);
            if(product.ProductId > 0)
            {
                _db.Update(product);
            }
            else
            {
                _db.Add(product);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Services.Product.Api.Models.Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {

            try
            {
                Services.Product.Api.Models.Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
                if(product == null)
                    return false;
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            List<Services.Product.Api.Models.Product> productList = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Services.Product.Api.Models.Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }
    }
}
