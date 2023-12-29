using AutoMapper;
using Restaurant.Services.CartAPI.Models;
using Restaurant.Services.CartAPI.Models.Dto;

namespace Restaurant.Services.CartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var MappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();

            });
            return MappingConfig;
        }
    }
}
