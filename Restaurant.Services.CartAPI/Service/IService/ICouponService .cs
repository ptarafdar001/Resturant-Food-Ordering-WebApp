using Restaurant.Services.CartAPI.Models.Dto;

namespace Restaurant.Services.CartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
