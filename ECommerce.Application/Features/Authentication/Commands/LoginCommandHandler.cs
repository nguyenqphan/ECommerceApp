using ECommerce.Application.DTOs.Authentication;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Application.Features.Authentication.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponseDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.LoginRequest.Email);
            if (user == null)
                throw new Exception("Invalid credentials.");

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.LoginRequest.Password, false);
            if (!result.Succeeded)
                throw new Exception("Invalid credentials.");

            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault() ?? "User";

            return new AuthResponseDto
            {
                UserId = user.Id,
                Email = user.Email!,
                Role = role,
                Token = "" // Placeholder, will be replaced with JWT
            };
        }
    }
}
