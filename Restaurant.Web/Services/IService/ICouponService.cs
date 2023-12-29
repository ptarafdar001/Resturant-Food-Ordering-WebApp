﻿using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IService
{
    public interface ICouponService
    {
        Task<ResponseDTO?> GetCouponAsync(string couponCode);
        Task<ResponseDTO?> GetAllCouponsAsync();
        Task<ResponseDTO?> GetCouponByIdAsync(int id);
        Task<ResponseDTO?> CreateCouponsAsync(CouponDTO couponDTO);
        Task<ResponseDTO?> UpdateCouponsAsync(CouponDTO couponDTO);
        Task<ResponseDTO?> DeleteCouponsAsync(int id);
    }
}
