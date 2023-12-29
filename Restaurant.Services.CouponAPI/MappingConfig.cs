using AutoMapper;
using Restaurant.Services.CouponAPI.Models;
using Restaurant.Services.CouponAPI.Models.DTO;

namespace Restaurant.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var MappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, Coupon>();
                config.CreateMap<Coupon, CouponDTO>();
            });
            return MappingConfig;
        }
    }
}
