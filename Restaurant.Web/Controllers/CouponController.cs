using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.Web.Models;
using Restaurant.Web.Services.IService;
using System.Collections;
using System.Collections.Generic;

namespace Restaurant.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDTO>? list = new();

            ResponseDTO? respose = await _couponService.GetAllCouponsAsync();
            
			if (respose != null && respose.IsSuccess) { 
            
				list = JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(respose.Result));  
            }
			else
			{
				TempData["error"] = respose?.Message;
			}

            return View(list);
        }

        public async Task<IActionResult> CouponCreate ()
        {
			return View();
		}

        [HttpPost]
		public async Task<IActionResult> CouponCreate(CouponDTO model)
		{
            if(ModelState.IsValid) 
            { 
			    ResponseDTO? respose = await _couponService.CreateCouponsAsync(model);
			    
                if (respose != null && respose.IsSuccess)
			    {
                    TempData["success"] = "Coupon created successfully";
                    return RedirectToAction(nameof(CouponIndex));
			    }
				else
				{
					TempData["error"] = respose?.Message;
				}
			}
			return View(model);
		}

		public async Task<IActionResult> CouponDelete(int couponId)
		{

			ResponseDTO? respose = await _couponService.GetCouponByIdAsync(couponId);
			
			if (respose != null && respose.IsSuccess)
			{
				CouponDTO? model = JsonConvert.DeserializeObject<CouponDTO>(Convert.ToString(respose.Result));
			    return View(model);
			}
			else
			{
				TempData["error"] = respose?.Message;
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> CouponDelete(CouponDTO couponDTO)
		{

			ResponseDTO? respose = await _couponService.DeleteCouponsAsync(couponDTO.CouponId);
			if (respose != null && respose.IsSuccess)
			{
                TempData["success"] = "Coupon deleted successfully";
                return RedirectToAction(nameof(CouponIndex));
			}
			else
			{
				TempData["error"] = respose?.Message;
			}
			return View(couponDTO);
		}
	}
}
