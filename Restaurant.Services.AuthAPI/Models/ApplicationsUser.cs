using Microsoft.AspNetCore.Identity;

namespace Restaurant.Services.AuthAPI.Models
{
    public class ApplicationsUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
