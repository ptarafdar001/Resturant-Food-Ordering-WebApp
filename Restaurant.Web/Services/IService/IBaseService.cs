
using Restaurant.Web.Models;

namespace Restaurant.Web.Services.IService
{
	public interface IBaseService
	{
		Task<ResponseDTO?> SendAsync(RequestDTO requestDTO, bool withBearer=true );
	}
}
