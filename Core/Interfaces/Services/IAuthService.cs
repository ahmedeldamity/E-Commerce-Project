using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager);
    }
}