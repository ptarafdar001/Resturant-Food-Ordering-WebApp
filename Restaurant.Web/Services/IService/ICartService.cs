using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IService
{
    public interface ICartService
    {
        Task<ResponseDTO?> GetCartByUserIdAsync(string UserId);
        Task<ResponseDTO?> UpsertCartAsync(CartDto cartDto);
        Task<ResponseDTO?> RemoveFromCartAsync(int cartDetailsId);
        Task<ResponseDTO?> ApplyCouponAsync(CartDto cartDto);
    }
}
