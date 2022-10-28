using AutoMapper;
using Services.Product.Api.Models.Dto;

namespace Services.Product.Api
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Services.Product.Api.Models.Product>();
                config.CreateMap<Services.Product.Api.Models.Product, ProductDto>();

            });
            return mappingConfig;   
        }
    }
}
