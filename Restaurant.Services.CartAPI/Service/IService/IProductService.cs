using Restaurant.Services.CartAPI.Models.Dto;

namespace Restaurant.Services.CartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
