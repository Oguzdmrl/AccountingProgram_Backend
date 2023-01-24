using AccountingSolutions.Domain.AppEntities.Identity;

namespace AccountingSolutions.Application.Abstractions
{
    public interface IJwtProvider
    {
       Task<string> CreateTokenAsync(AppUser user, List<string> roles);
    }
}