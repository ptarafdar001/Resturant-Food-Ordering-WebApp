using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.Web.Models;
using Restaurant.Web.Services.IService;

namespace Restaurant.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto>? list = new();

            ResponseDTO? respose = await _productService.GetAllProductsAsync();
            
			if (respose != null && respose.IsSuccess) { 
            
				list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(respose.Result));  
            }
			else
			{
				TempData["error"] = respose?.Message;
			}

            return View(list);
        }

        public async Task<IActionResult> ProductCreate()
        {
			return View();
		}

        [HttpPost]
		public async Task<IActionResult> ProductCreate(ProductDto model)
		{
            if(ModelState.IsValid) 
            { 
			    ResponseDTO? respose = await _productService.CreateProductsAsync(model);
			    
                if (respose != null && respose.IsSuccess)
			    {
                    TempData["success"] = "Product created successfully";
                    return RedirectToAction(nameof(ProductIndex));
			    }
				else
				{
					TempData["error"] = respose?.Message;
				}
			}
			return View(model);
		}

        public async Task<IActionResult> ProductEdit(int productId)
        {

            ResponseDTO? respose = await _productService.GetProductByIdAsync(productId);

            if (respose != null && respose.IsSuccess)
            {
                ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(respose.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = respose?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductDto productDto)
        {

            ResponseDTO? respose = await _productService.UpdateProductsAsync(productDto);
            if (respose != null && respose.IsSuccess)
            {
                TempData["success"] = "Product updated successfully";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = respose?.Message;
            }
            return View(productDto);
        }

        public async Task<IActionResult> ProductDelete(int productId)
		{

			ResponseDTO? respose = await _productService.GetProductByIdAsync(productId);
			
			if (respose != null && respose.IsSuccess)
			{
				ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(respose.Result));
			    return View(model);
			}
			else
			{
				TempData["error"] = respose?.Message;
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> ProductDelete(ProductDto productDto)
		{

			ResponseDTO? respose = await _productService.DeleteProductsAsync(productDto.ProductId);
			if (respose != null && respose.IsSuccess)
			{
                TempData["success"] = "Product deleted successfully";
                return RedirectToAction(nameof(ProductIndex));
			}
			else
			{
				TempData["error"] = respose?.Message;
			}
			return View(productDto);
		}
	}
}
