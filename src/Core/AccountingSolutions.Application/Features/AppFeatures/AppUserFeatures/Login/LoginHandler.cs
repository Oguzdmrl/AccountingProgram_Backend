using AccountingSolutions.Application.Abstractions;
using AccountingSolutions.Domain.AppEntities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AccountingSolutions.Application.Features.AppFeatures.AppUserFeatures.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IJwtProvider _jwtprovider;
        private readonly UserManager<AppUser> _userManager;
        public LoginHandler(IJwtProvider jwtprovider, UserManager<AppUser> userManager)
        {
            _jwtprovider = jwtprovider;
            _userManager = userManager;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.Users.Where(p => p.Email ==
            request.EmailOrUserName ||
            p.UserName == request.EmailOrUserName).FirstOrDefaultAsync();

            if (user == null) throw new Exception("Kullanıcı Bulunamadı!");

            var checkUser = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!checkUser) throw new Exception("Şifreniz Yanlış!");

            List<string> roles = new();

            LoginResponse response = new()
            {
                Email = user.Email,
                NameLastName = user.NameLastName,
                UserId = user.Id,
                Token = await _jwtprovider.CreateTokenAsync(user, roles)
            };
            return response;

        }
    }
}