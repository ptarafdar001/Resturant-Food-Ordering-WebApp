﻿using Restaurant.Web.Models;
using Restaurant.Web.Services.IService;
using Restaurant.Web.Utility;

namespace Restaurant.Web.Services
{
    public class CouponServices : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponServices(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDTO?> CreateCouponsAsync(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = couponDTO,
                Url = SD.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDTO?> DeleteCouponsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponAPIBase + "/api/coupon/"+id
            });
        }

        public async Task<ResponseDTO?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDTO?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/GetByCode/" + couponCode
            });
        }

        public async Task<ResponseDTO?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/"+id
            });
        }

        public async Task<ResponseDTO?> UpdateCouponsAsync(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.PUT,
                Data = couponDTO,
                Url = SD.CouponAPIBase + "/api/coupon"
            });
        }
    }
}
