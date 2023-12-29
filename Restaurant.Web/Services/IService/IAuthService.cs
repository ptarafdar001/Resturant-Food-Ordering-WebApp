using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IService
{
    public interface IAuthService
    {
        Task<ResponseDTO?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDTO?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDTO?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
    }
}
